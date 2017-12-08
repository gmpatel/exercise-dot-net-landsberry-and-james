using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave;
using AnnualLeave.Core;
using AnnualLeave.Exceptions;
using AnnualLeave.LeaveValidators;
using AnnualLeave.Logging;
using AnnualLeave.Logging.Core;
using AnnualLeave.Repositories;

namespace AnnualLeave
{
    public class EmployeeLeave : IEmployeeLeave
    {
        private readonly ILeaveValidator validator;
        private readonly IRepository repository;
        private readonly ILogger logger;

        // Empty constructor to provide support to existing client applications without code change
        // Existing client applications are constructing direct objects for EmployeeLeave using default/empty constructor
        // Newly created empty constructor will stop breaking exisitng applications and will self inject 'Default' Repository and Validator which will support the exsting logic of existing framework/application

        public EmployeeLeave() : this(new DefaultRepository(), new DefaultLeaveValidator(), Logger.Instance())
        {
            logger.Info("Empty Constructor Called");
        }

        public EmployeeLeave(IRepository repository, ILeaveValidator validator, ILogger logger)
        {
            logger.Info("Parameterised Constructor Called");

            this.repository = repository;
            this.validator = validator;
            this.logger = logger;

            logger.InfoFormat("Type of Repository (IRepository) injected by IoC, repository = {0}", this.repository.GetType());
            logger.InfoFormat("Type of Leave Validator (ILeaveValidator) injected by IoC, validator = {0}", this.validator.GetType());
            logger.InfoFormat("Type of Logger (ILogger) injected by IoC, logger= {0}", this.logger.GetType());
        }

        public void ProcessLeaveRequest(DateTime leaveStartDate, int days, string reason, int employeeId)
        {
            var employee = FindEmployee(employeeId);

            if (employee != null)
            {
                logger.InfoFormat("Employee found! Id = {0}, Name = {1} {2}", employeeId, employee.Name, employee.LastName);

                var leaveRequest = new EmployeeLeaveRequest
                {
                    EmployeeId = employeeId,
                    LeaveStartDateTime = leaveStartDate,
                    LeaveEndDateTime = leaveStartDate.AddDays(days),
                    IsApproved = false
                };

                try
                {
                    logger.InfoFormat("Going to validate leave request for employee id {0} - {1} {2}, with validator ({3})", employeeId, employee.Name, employee.LastName, this.validator.GetType());

                    validator.Validate(employee, leaveStartDate, days, reason);
                    leaveRequest.IsApproved = true;

                    logger.InfoFormat("Leave request for employee id {0} - {1} {2}, approved!", employeeId, employee.Name, employee.LastName);                    
                }
                catch (InvalidLeaveRequestException exception)
                {
                    logger.ErrorFormat("Leave Request approval failed - {0}", exception.Message, exception);
                }
                catch (Exception exception)
                {
                    logger.ErrorFormat("Leave Request approval failed. Unknown exception - {0}", exception.Message, exception);
                }

                SaveLeaveRequest(leaveRequest);
            }
        }

        public void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest)
        {
            repository.SaveLeaveRequest(leaveRequest);
        }

        public Employee FindEmployee(int employeeId)
        {
            try
            {
                return repository.FindEmployee(employeeId);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                logger.ErrorFormat("Employee with employee id {0} not found - {1}", employeeId, exception.Message, exception);
                return null;
            }
            catch (Exception exception)
            {
                logger.ErrorFormat("Employee with employee id {0} not found. Unknown exception - {1}", employeeId, exception.Message, exception);
                return null;
            }
        }

        public IEnumerable<EmployeeLeaveRequest> GetLeaveRequests(int employeeId)
        {
            try
            {
                return repository.GetLeaveRequests(employeeId);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                logger.ErrorFormat("Employee with employee id {0} not found - {1}", employeeId, exception.Message, exception);
                return null;
            }
            catch (Exception exception)
            {
                logger.ErrorFormat("Employee with employee id {0} not found. Unknown exception - {1}", employeeId, exception.Message, exception);
                return null;
            }
        }
    }
}