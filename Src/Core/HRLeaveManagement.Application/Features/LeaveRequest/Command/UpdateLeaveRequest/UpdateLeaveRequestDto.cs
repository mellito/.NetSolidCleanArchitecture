using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.Shared;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest
{
    public class UpdateLeaveRequestDto : BaseLeaveRequest
    {
        public string RequestComments { get; set; } = string.Empty;
        public bool Cancelled { get; set; }
    }
}