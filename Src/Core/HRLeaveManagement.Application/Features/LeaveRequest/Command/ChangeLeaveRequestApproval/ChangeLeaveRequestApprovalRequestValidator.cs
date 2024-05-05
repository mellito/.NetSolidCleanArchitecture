using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalRequestValidator : AbstractValidator<ChangeLeaveRequestApprovalRequest>
    {
        public ChangeLeaveRequestApprovalRequestValidator()
        {
            RuleFor(x => x.LeaveRequestDto.Approved)
            .NotNull()
            .WithMessage("Approval status cannot be null");
        }
    }
}