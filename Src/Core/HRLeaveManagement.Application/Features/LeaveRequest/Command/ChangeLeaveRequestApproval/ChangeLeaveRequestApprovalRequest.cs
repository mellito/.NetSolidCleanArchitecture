using HRLeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public ChangeLeaveRequestApprovalDto LeaveRequestDto { get; set; }

        public ChangeLeaveRequestApprovalRequest(ChangeLeaveRequestApprovalDto leaveRequestDto, int id)
        {
            LeaveRequestDto = leaveRequestDto;
            Id = id;
        }
    }
}