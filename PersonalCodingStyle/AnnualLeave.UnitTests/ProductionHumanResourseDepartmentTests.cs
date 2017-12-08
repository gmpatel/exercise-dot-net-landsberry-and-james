using System;
using System.Linq;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using AnnualLeave.MicrosoftContainer;
using AnnualLeave.Enums;
using AnnualLeave.Core;

namespace AnnualLeave.UnitTests
{
    [TestFixture]
    public class ProductionHumanResourseDepartmentTests
    {
        [Test]
        public void ProductionLeaveValidator_ValidLeave_Test_1_Approved()
        {
            //Arrange
            const int employeeId = 1;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Production.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 3, "Family outing!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, true);

            //Log
            //2015-09-26 09:49:32,521 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 09:49:32,595 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 09:49:32,599 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.ProductionHumanResourceDepartmentLeaveValidator
            //2015-09-26 09:49:32,601 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 09:49:32,605 [Runner thread] INFO  Log4Net Employee found! Id = 1, Name = Aditi Patel
            //2015-09-26 09:49:32,607 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 1 - Aditi Patel, with validator (AnnualLeave.CustomLeaveValidators.ProductionHumanResourceDepartmentLeaveValidator)
            //2015-09-26 09:49:32,608 [Runner thread] INFO  Log4Net Leave request for employee id 1 - Aditi Patel, approved!
        }

        [Test]
        public void ProductionLeaveValidator_InvalidLeave_Test_2_NotApproved()
        {
            //Arrange
            const int employeeId = 6;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Production.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 3, "Need a break from work!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, false);

            //Log
            //2015-09-26 09:46:59,585 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 09:46:59,684 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 09:46:59,690 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.ProductionHumanResourceDepartmentLeaveValidator
            //2015-09-26 09:46:59,692 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 09:46:59,696 [Runner thread] INFO  Log4Net Employee found! Id = 6, Name = Ankit Patel
            //2015-09-26 09:46:59,699 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 6 - Ankit Patel, with validator (AnnualLeave.CustomLeaveValidators.ProductionHumanResourceDepartmentLeaveValidator)
            //2015-09-26 09:46:59,702 [Runner thread] ERROR Log4Net Leave Request approval failed - Invalid leave request. Ankit Patel is unmarried. Unmarried employees of production department do not get leave till 6 months!
        }

        [Test]
        public void ProductionLeaveValidator_InvalidLeave_Test_3_NotApproved()
        {
            //Arrange
            const int employeeId = 1;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Production.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 7, "Need a break from work!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, false);

            //Log
            //2015-09-26 09:50:46,473 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 09:50:46,546 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 09:50:46,550 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.ProductionHumanResourceDepartmentLeaveValidator
            //2015-09-26 09:50:46,551 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 09:50:46,560 [Runner thread] INFO  Log4Net Employee found! Id = 1, Name = Aditi Patel
            //2015-09-26 09:50:46,562 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 1 - Aditi Patel, with validator (AnnualLeave.CustomLeaveValidators.ProductionHumanResourceDepartmentLeaveValidator)
            //2015-09-26 09:50:46,565 [Runner thread] ERROR Log4Net Leave Request approval failed - Invalid leave request. Aditi Patel has applied for 7 days of leave. Can't approve leave request of more than 5 days for production department!
        }
    }
}