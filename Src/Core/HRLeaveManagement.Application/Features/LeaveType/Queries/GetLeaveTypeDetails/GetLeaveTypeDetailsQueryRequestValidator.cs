using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryRequestValidator : AbstractValidator<GetLeaveTypeDetailsQueryRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailsQueryRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(l => l.Id)
            .GreaterThan(0)
            .WithMessage("Id can be not 0")
            .NotNull();

            RuleFor(p => p)
            .MustAsync(LeaveTypeExist)
            .WithMessage("Leave type not exists");

            _leaveTypeRepository = leaveTypeRepository;
        }

        private async Task<bool> LeaveTypeExist(GetLeaveTypeDetailsQueryRequest request, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeExist(request.Id);
        }
    }
}