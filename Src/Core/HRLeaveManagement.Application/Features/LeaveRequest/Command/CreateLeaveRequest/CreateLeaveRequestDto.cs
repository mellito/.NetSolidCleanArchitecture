using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.Shared;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest
{
    public class CreateLeaveRequestDto : BaseLeaveRequest
    {
        public string RequestComment { get; set; } = string.Empty;
    }
}