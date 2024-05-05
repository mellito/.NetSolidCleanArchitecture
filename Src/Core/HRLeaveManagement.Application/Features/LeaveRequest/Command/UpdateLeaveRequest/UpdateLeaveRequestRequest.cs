using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest
{
    public class UpdateLeaveRequestRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto leaveRequestToUpdate { get; set; }
        public UpdateLeaveRequestRequest(int id, UpdateLeaveRequestDto leaveRequestToUpdate)
        {
            Id = id;
            this.leaveRequestToUpdate = leaveRequestToUpdate;
        }
    }
}