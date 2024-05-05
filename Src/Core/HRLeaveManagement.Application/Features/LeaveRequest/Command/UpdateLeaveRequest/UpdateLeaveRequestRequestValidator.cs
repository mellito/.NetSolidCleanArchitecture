using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.Shared;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest
{
    public class UpdateLeaveRequestRequestValidator : AbstractValidator<UpdateLeaveRequestRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveRequestRequestValidator(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.leaveRequestToUpdate).SetValidator(new BaseLeaveRequestValidator(_leaveTypeRepository));
            RuleFor(p => p.Id)
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