using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualLeave.Core
{
    public interface ILeaveValidator
    {
        void Validate(Employee employee, DateTime leaveStartDate, int days, string reason);
    }
}