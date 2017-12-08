using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Core;

namespace AnnualLeave.Repositories
{
    public class DefaultRepository : IRepository
    {
        // This class will allow supporting exisitng applications with no code change for existing SQL Server based repository
        // Logic of this class has been extracted from the 'EmployeeLeave' class of original/existing application 

        // I understand from the description of coding test (PDF) that we have to treat that existing logic for SQL is working and have to support the exisiting client applications (backward compatibility) without code change

        public void SaveLeaveRequest(EmployeeLeaveRequest leaveRequest)
        {
            var sqlConnection = new SqlConnection("Data Source=local;Initial Catalog=Employee;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into EmployeeLeave (EmployeeId, StartDateTime, EndDateTime) values ('@EmployeeId','@StartDateTime', '@EndDateTime')";
            cmd.Parameters.AddWithValue("EmployeeId", leaveRequest.EmployeeId);
            cmd.Parameters.AddWithValue("StartDateTime", leaveRequest.LeaveStartDateTime);
            cmd.Parameters.AddWithValue("EndDateTime", leaveRequest.LeaveEndDateTime);
            cmd.ExecuteNonQuery();
        }

        public Employee FindEmployee(int employeeId)
        {
            var sqlConnection = new SqlConnection("Data Source=local;Initial Catalog=Employee;Integrated Security=True");
            var sql = "SELECT * from Employee WHERE EmployeeID=" + employeeId;
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlConnection.Open();
            var sqlReader = sqlCommand.ExecuteReader();

            Employee employee = null;
            if (sqlReader.Read())
            {
                employee = new Employee();

                employee.EmployeeId = int.Parse(sqlReader["EmployeeId"].ToString());
                employee.Name = sqlReader["Name"].ToString();
                employee.LastName = sqlReader["LastName"].ToString();
                employee.ContactStartDate = DateTime.Parse(sqlReader["StartDate"].ToString());
                employee.Salary = Decimal.Parse(sqlReader["Salary"].ToString());
            }
            return employee;
        }

        public IEnumerable<EmployeeLeaveRequest> GetLeaveRequests(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}