using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailRequest : IRequest<GetLeaveAllocationDetailDto>
    {
        public int Id { get; set; }
        public GetLeaveAllocationDetailRequest(int id)
        {
            Id = id;
        }
    }
}