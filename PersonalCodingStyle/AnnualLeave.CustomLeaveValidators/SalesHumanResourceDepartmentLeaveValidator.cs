using System;
using AnnualLeave.Core;
using AnnualLeave.Exceptions;

namespace AnnualLeave.CustomLeaveValidators
{
    public class SalesHumanResourceDepartmentLeaveValidator : ILeaveValidator
    {
        public void Validate(Employee employee, DateTime leaveStartDate, int days, string reason)
        {
            if (employee.IsMarried)
                throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} is married. Married sales people do not need holidays! Keep selling...", employee.Name, employee.LastName));

            if (days < 3)
                throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} has applied for {2} days of leave. Can't approve short leave request of less than 3 days for sales department! Spend more leaves...", employee.Name, employee.LastName, days));
        }
    }
}