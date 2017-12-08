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
    public class SalesHumanResourseDepartmentTests
    {
        [Test]
        public void SalesLeaveValidator_InalidLeave_Test_1_Approved()
        {
            //Arrange
            const int employeeId = 6;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Sales.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 7, "Want to go on a overseas tour!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, true);

            //Log
            //2015-09-26 10:09:18,630 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 10:09:18,720 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 10:09:18,725 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.SalesHumanResourceDepartmentLeaveValidator
            //2015-09-26 10:09:18,726 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 10:09:18,730 [Runner thread] INFO  Log4Net Employee found! Id = 6, Name = Ankit Patel
            //2015-09-26 10:09:18,732 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 6 - Ankit Patel, with validator (AnnualLeave.CustomLeaveValidators.SalesHumanResourceDepartmentLeaveValidator)
            //2015-09-26 10:09:18,734 [Runner thread] INFO  Log4Net Leave request for employee id 6 - Ankit Patel, approved!
        }

        [Test]
        public void SalesLeaveValidator_InvalidLeave_Test_2_NotApproved()
        {
            //Arrange
            const int employeeId = 9;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Sales.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 7, "Family outing!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, false);

            //Log
            //2015-09-26 10:10:13,021 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 10:10:13,101 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 10:10:13,106 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.SalesHumanResourceDepartmentLeaveValidator
            //2015-09-26 10:10:13,107 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 10:10:13,110 [Runner thread] INFO  Log4Net Employee found! Id = 9, Name = Chirag Patel
            //2015-09-26 10:10:13,113 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 9 - Chirag Patel, with validator (AnnualLeave.CustomLeaveValidators.SalesHumanResourceDepartmentLeaveValidator)
            //2015-09-26 10:10:13,115 [Runner thread] ERROR Log4Net Leave Request approval failed - Invalid leave request. Chirag Patel is married. Married sales people do not need holidays! Keep selling...
        }

        [Test]
        public void SalesLeaveValidator_InvalidLeave_Test_3_NotApproved()
        {
            //Arrange
            const int employeeId = 6;
            var employeeLeave = UnityBootstrapper.Container.Resolve<IEmployeeLeave>(Department.Sales.ToString());

            //Act
            employeeLeave.ProcessLeaveRequest(DateTime.Now.AddDays(1), 2, "Need a short break from work!", employeeId);
            var request = employeeLeave.GetLeaveRequests(employeeId).ToList().Last();

            //Assert
            Assert.AreEqual(request.IsApproved, false);

            //Log
            //2015-09-26 10:12:42,181 [Runner thread] INFO  Log4Net >> Method = .ctor(), Class Name = EmployeeLeave, Full Name = AnnualLeave.EmployeeLeave << Parameterised Constructor Called
            //2015-09-26 10:12:42,262 [Runner thread] INFO  Log4Net Type of Repository (IRepository) injected by IoC, repository = AnnualLeave.CustomRepositories.SimpleOfflineRepository
            //2015-09-26 10:12:42,266 [Runner thread] INFO  Log4Net Type of Leave Validator (ILeaveValidator) injected by IoC, validator = AnnualLeave.CustomLeaveValidators.SalesHumanResourceDepartmentLeaveValidator
            //2015-09-26 10:12:42,267 [Runner thread] INFO  Log4Net Type of Logger (ILogger) injected by IoC, logger= AnnualLeave.Logging.Logger
            //2015-09-26 10:12:42,270 [Runner thread] INFO  Log4Net Employee found! Id = 6, Name = Ankit Patel
            //2015-09-26 10:12:42,271 [Runner thread] INFO  Log4Net Going to validate leave request for employee id 6 - Ankit Patel, with validator (AnnualLeave.CustomLeaveValidators.SalesHumanResourceDepartmentLeaveValidator)
            //2015-09-26 10:12:42,274 [Runner thread] ERROR Log4Net Leave Request approval failed - Invalid leave request. Ankit Patel has applied for 2 days of leave. Can't approve leave request of less than 3 days for sales department!
        }
    }
}