using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.CancelLeaveRequest
{
    public class CancelLeaveRequestRequestValidator : AbstractValidator<CancelLeaveRequestRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public CancelLeaveRequestRequestValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            RuleFor(l => l.Id)
            .GreaterThan(0)
            .MustAsync(LeaveRequestMustExist)
            .WithMessage("{PropertyName} don't exist");
        }
        private async Task<bool> LeaveRequestMustExist(int id, CancellationToken token)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveRequest != null;
        }
    }
}