using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationRequest : IRequest<int>
    {
        public CreateLeaveAllocationDto CreateData { get; set; }
        public CreateLeaveAllocationRequest(CreateLeaveAllocationDto _createData)
        {
            CreateData = _createData;

        }
    }
}