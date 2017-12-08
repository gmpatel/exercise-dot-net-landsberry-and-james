using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Core;
using AnnualLeave.Exceptions;

namespace AnnualLeave.LeaveValidators
{
    // This class will allow supporting exisitng applications with no code change
    // This class has been extracted from the 'EmployeeLeave' class of original/existing application 

    // I understand from the description of coding test (PDF) that we have to support existing logic for leave request approval so that the exisiting client applications (backward compatibility) will work without any code change

    public class DefaultLeaveValidator : ILeaveValidator
    {
        public void Validate(Employee employee, DateTime leaveStartDate, int days, string reason)
        {
            if ((DateTime.Now - employee.ContactStartDate).TotalDays <= 90 && !employee.IsMarried)
                throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} has joined company within last 90 days and unmarried. Can't approve leave request for the unmarried employees hasn't completed 90 days!", employee.Name, employee.LastName));

            if (days > 20)
               throw new InvalidLeaveRequestException(string.Format("Invalid leave request. {0} {1} has applied for {2} days of leave. Can't approve leave request of more than 20 days for this department!", employee.Name, employee.LastName, days));
        }
    }
}