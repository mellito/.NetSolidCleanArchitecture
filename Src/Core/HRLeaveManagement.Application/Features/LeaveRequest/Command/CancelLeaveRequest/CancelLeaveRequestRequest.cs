using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.CancelLeaveRequest
{
    public class CancelLeaveRequestRequest : IRequest<Unit>
    {
        public int Id { get; set; }

        public CancelLeaveRequestRequest(int id)
        {
            Id = id;
        }
    }
}