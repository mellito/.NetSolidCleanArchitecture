using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandRequestValidator : AbstractValidator<DeleteLeaveTypeCommandRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(l => l.Id)
            .GreaterThan(0)
            .WithMessage("Id can be not 0")
            .NotNull()
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("Leave type must exist"); ;

            _leaveTypeRepository = leaveTypeRepository;
        }
        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }
    }
}