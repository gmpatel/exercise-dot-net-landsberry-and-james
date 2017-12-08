using System;
using System.Collections.Generic;

namespace AnnualLeave.Core
{
    public interface IEmployeeLeave
    {
        void ProcessLeaveRequest(DateTime leaveStartDate, int days, string reason, int employeeId);
        Employee FindEmployee(int employeeId);
        IEnumerable<EmployeeLeaveRequest> GetLeaveRequests(int employeeId);
    }
}

// --------------------------------------------------------------------------
// This method is removed only from the interface 'IEmployeeLeave' after extracting interface from original 'EmployeeLeave' class of existing application/framework
// So the upgraded versions of application/framework; which will resolve implementation of 'IEmployeeLeave' using IoC container
// will only have option to call 'ProcessLeaveRequest' to process the leave
// They will not able to call 'SaveLeaveRequest' or 'FindEmployee' directly using object type as 'IEmployeeLeave'
// --------------------------------------------------------------------------
// void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest);
// --------------------------------------------------------------------------