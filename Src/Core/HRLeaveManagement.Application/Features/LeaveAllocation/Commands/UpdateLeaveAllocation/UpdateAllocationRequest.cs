using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateAllocationRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateAllocationDto UpdateData { get; set; }
        public UpdateAllocationRequest(int id, UpdateAllocationDto updateData)
        {
            Id = id;
            UpdateData = updateData;

        }

    }
}