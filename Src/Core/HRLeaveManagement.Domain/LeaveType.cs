using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Domain.Common;

namespace HRLeaveManagement.Domain
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; } = "";
        public int DefaultDate { get; set; }
    }
}