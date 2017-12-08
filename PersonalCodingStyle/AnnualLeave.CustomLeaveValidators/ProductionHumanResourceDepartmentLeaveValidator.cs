using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Core;
using AnnualLeave.Exceptions;

namespace AnnualLeave.CustomLeaveValidators
{
    public class ProductionHumanResourceDepartmentLeaveValidator : ILeaveValidator
    {
        public void Validate(Employee employee, DateTime leaveStartDate, int days, string reason)
        {
            if ((DateTime.Now - employee.ContactStartDate).TotalDays <= 180 && !employee.IsMarried)
                throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} is unmarried. Unmarried employees of production department do not get leave till 6 months!", employee.Name, employee.LastName));

            if (days > 5)
                throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} has applied for {2} days of leave. Can't approve leave request of more than 5 days for production department!", employee.Name, employee.LastName, days));

        }
    }
}