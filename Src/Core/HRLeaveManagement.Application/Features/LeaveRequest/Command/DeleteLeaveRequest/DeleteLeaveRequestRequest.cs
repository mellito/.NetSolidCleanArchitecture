using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.DeleteLeaveRequest
{
    public class DeleteLeaveRequestRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteLeaveRequestRequest(int id)
        {
            Id = id;
        }
    }
}