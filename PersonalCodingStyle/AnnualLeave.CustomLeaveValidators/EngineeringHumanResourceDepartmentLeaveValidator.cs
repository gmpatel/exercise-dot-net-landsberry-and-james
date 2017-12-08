using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Core;
using AnnualLeave.Exceptions;

namespace AnnualLeave.CustomLeaveValidators
{
    public class EngineeringHumanResourceDepartmentLeaveValidator : ILeaveValidator
    {
        public void Validate(Employee employee, DateTime leaveStartDate, int days, string reason)
        {
            if (!employee.IsMarried)
                throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} is unmarried. Unmarried engineers do not need holidays!", employee.Name, employee.LastName));

            if (days > 45)
                throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} has applied for {2} days of leave. Can't approve leave request of more than 45 days for engineering department!", employee.Name, employee.LastName, days));
        }
    }
}