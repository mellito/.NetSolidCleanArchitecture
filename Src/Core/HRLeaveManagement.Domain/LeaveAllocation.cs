using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Domain.Common;

namespace HRLeaveManagement.Domain
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
    }
}