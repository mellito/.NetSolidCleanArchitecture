using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocationsRequest : IRequest<List<GetLeaveAllocationDto>>
    {
        public GetLeaveAllocationsRequest()
        {
        }
    }
}