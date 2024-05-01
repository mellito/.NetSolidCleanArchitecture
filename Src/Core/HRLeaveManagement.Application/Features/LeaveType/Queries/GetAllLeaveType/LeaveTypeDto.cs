using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public class LeaveTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int DefaultDate { get; set; }
    }
}