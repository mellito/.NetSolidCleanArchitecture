using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest
{
    public class LeaveRequestListDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto? LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
        public string RequestingEmployeeId { get; set; } = string.Empty;
    }
}