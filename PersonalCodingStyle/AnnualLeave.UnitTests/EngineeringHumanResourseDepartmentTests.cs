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
    public class EngineeringHumanResourseDepartmentTests
    {
        [Test]
        public void EngineeringLeaveValidator_Test_1_ValidLeave_Approved()
        {
            //Arrange
            const int employeeId = 21;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Engineering.ToString());
            
            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 3, "Family outing!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, true);

            //Log
            //2015-09-26 09:37:58,543 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 09:37:58,620 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 09:37:58,624 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.EngineeringHumanResourceDepartmentLeaveValidator
            //2015-09-26 09:37:58,625 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 09:37:58,629 [Runner thread] INFO  Log4Net Employee found! Id = 21, Name = Gunjan Patel
            //2015-09-26 09:37:58,631 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 21 - Gunjan Patel, with validator (AnnualLeave.CustomLeaveValidators.EngineeringHumanResourceDepartmentLeaveValidator)
            //2015-09-26 09:37:58,633 [Runner thread] INFO  Log4Net Leave request for employee id 21 - Gunjan Patel, approved!
        }

        [Test]
        public void EngineeringLeaveValidator_Test_2_InvalidLeave_NotApproved()
        {
            //Arrange
            const int employeeId = 6;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Engineering.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 7, "Need break from the routine!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, false);

            //Log
            //2015-09-26 09:35:56,639 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 09:35:56,736 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 09:35:56,740 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.EngineeringHumanResourceDepartmentLeaveValidator
            //2015-09-26 09:35:56,741 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 09:35:56,745 [Runner thread] INFO  Log4Net Employee found! Id = 6, Name = Ankit Patel
            //2015-09-26 09:35:56,747 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 6 - Ankit Patel, with validator (AnnualLeave.CustomLeaveValidators.EngineeringHumanResourceDepartmentLeaveValidator)
            //2015-09-26 09:35:56,837 [Runner thread] ERROR Log4Net Leave Request approval failed - Invalid leave request. Ankit Patel is unmarried. Unmarried engineers do not need holidays!
        }

        [Test]
        public void EngineeringLeaveValidator_Test_3_InvalidLeave_NotApproved()
        {
            //Arrange
            const int employeeId = 21;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Engineering.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 60, "Need break from the routine!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, false);

            //Log
            //2015-09-26 09:39:03,571 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 09:39:03,649 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 09:39:03,654 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.EngineeringHumanResourceDepartmentLeaveValidator
            //2015-09-26 09:39:03,655 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 09:39:03,659 [Runner thread] INFO  Log4Net Employee found! Id = 21, Name = Gunjan Patel
            //2015-09-26 09:39:03,661 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 21 - Gunjan Patel, with validator (AnnualLeave.CustomLeaveValidators.EngineeringHumanResourceDepartmentLeaveValidator)
            //2015-09-26 09:39:03,663 [Runner thread] ERROR Log4Net Leave Request approval failed - Invalid leave request. Gunjan Patel has applied for 60 days of leave. Can't approve leave request of more than 45 days for engineering department!
        }
    }
}