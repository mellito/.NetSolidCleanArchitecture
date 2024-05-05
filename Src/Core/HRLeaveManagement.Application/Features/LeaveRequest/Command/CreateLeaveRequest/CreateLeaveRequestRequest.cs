using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest
{
    public class CreateLeaveRequestRequest : IRequest<int>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }

        public CreateLeaveRequestRequest(CreateLeaveRequestDto leaveRequestDto)
        {
            this.LeaveRequestDto = leaveRequestDto;
        }
    }
}