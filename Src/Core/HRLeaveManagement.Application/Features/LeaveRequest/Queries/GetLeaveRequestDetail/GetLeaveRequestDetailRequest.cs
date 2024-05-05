using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDetailDto>
    {
        public int Id { get; set; }
        public GetLeaveRequestDetailRequest(int id)
        {
            Id = id;
        }
    }
}