using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteLeaveAllocationRequest(int id)
        {
            Id = id;
        }

    }
}