using System;
using System.Collections.Generic;
using AnnualLeave.Core;

namespace AnnualLeave.CustomRepositories
{
    public class SimpleOfflineRepository : IRepository
    {
        private readonly Dictionary<int, Employee> employees;
        private readonly Dictionary<int, List<EmployeeLeaveRequest>> employeeLeaveRequests;

        public SimpleOfflineRepository()
        {
            employees = GenerateData();
            employeeLeaveRequests = new Dictionary<int, List<EmployeeLeaveRequest>>();
        }

        public void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest)
        {
            if (employeeLeaveRequests.ContainsKey(leaveRequest.EmployeeId))                                            
            {
                employeeLeaveRequests[leaveRequest.EmployeeId].Add(leaveRequest);
                return;
            }

            employeeLeaveRequests[leaveRequest.EmployeeId] = new List<EmployeeLeaveRequest> {leaveRequest};
        }

        public Employee FindEmployee(int employeeId)
        {
            if (employees.ContainsKey(employeeId))
                return employees[employeeId];
            
            throw new ArgumentOutOfRangeException("employeeId", string.Format("Argument '{0}' Value = {1} is out of range OR employee not found!", "employeeId", employeeId));
        }

        public IEnumerable<EmployeeLeaveRequest> GetLeaveRequests(int employeeId)
        {
            if (!employees.ContainsKey(employeeId))
                throw new ArgumentOutOfRangeException("employeeId", string.Format("Argument '{0}' Value = {1} is out of range OR employee not found!", "employeeId", employeeId));

            if(!employeeLeaveRequests.ContainsKey(employeeId))
                return new List<EmployeeLeaveRequest>();

            return employeeLeaveRequests[employeeId];
        }

        private static Dictionary<int, Employee> GenerateData()
        {
            return new Dictionary<int, Employee>
            {
                {
                    1, new Employee
                    {
                        EmployeeId = 1,
                        Name = "Aditi",
                        LastName = "Patel",
                        IsMarried = true,
                        ContactStartDate = DateTime.Now.AddMonths(-5),
                        Salary = 1000
                    }
                },
                {
                    6, new Employee
                    {
                        EmployeeId = 6,
                        Name = "Ankit",
                        LastName = "Patel",
                        IsMarried = false,
                        ContactStartDate = DateTime.Now.AddMonths(-2),
                        Salary = 1100
                    }
                },
                {
                    9, new Employee
                    {
                        EmployeeId = 9,
                        Name = "Chirag",
                        LastName = "Patel",
                        IsMarried = true,
                        ContactStartDate = DateTime.Now.AddYears(-3),
                        Salary = 1500
                    }
                },
                {
                    18, new Employee
                    {
                        EmployeeId = 18,
                        Name = "Dhyey",
                        LastName = "Patel",
                        IsMarried = false,
                        ContactStartDate = DateTime.Now.AddYears(-5),
                        Salary = 2000
                    }
                },
                {
                    21, new Employee
                    {
                        EmployeeId = 21,
                        Name = "Gunjan",
                        LastName = "Patel",
                        IsMarried = true,
                        ContactStartDate = DateTime.Now.AddYears(-2),
                        Salary = 1200
                    }
                }
            };
        }
    }
}