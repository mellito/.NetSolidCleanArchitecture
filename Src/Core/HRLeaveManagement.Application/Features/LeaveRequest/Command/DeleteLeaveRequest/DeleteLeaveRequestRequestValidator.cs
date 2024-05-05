using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.DeleteLeaveRequest
{
    public class DeleteLeaveRequestRequestValidator : AbstractValidator<DeleteLeaveRequestRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public DeleteLeaveRequestRequestValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            RuleFor(request => request.Id)
            .GreaterThan(0)
            .MustAsync(leaveRequestMustExist);
        }

        private async Task<bool> leaveRequestMustExist(int id, CancellationToken token)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveRequest != null;
        }
    }
}