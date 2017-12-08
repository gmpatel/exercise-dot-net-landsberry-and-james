using System.Collections.Generic;

namespace AnnualLeave.Core
{
    public interface IRepository
    {
        void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest);
        Employee FindEmployee(int employeeId);                      
        IEnumerable<EmployeeLeaveRequest> GetLeaveRequests(int employeeId);
    }
}