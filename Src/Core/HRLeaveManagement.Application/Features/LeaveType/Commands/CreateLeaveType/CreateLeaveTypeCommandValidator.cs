using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommandRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Name).NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(70)
            .WithMessage("{PropertyName} must be fewer that 70 characters ");

            RuleFor(p => p.DefaultDays)
            .LessThan(100)
            .WithMessage("{PropertyName} Cannot Exceed 100")
            .GreaterThan(1)
            .WithMessage("{PropertyName} cannot be less than 1 ");

            RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type already exists");

            _leaveTypeRepository = leaveTypeRepository;
        }

        private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommandRequest request, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeUnique(request.Name);
        }
    }
}