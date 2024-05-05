using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateAllocationRequestValidator : AbstractValidator<UpdateAllocationRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateAllocationRequestValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;

            RuleFor(p => p.UpdateData.NumberOfDays)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(p => p.UpdateData.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.UpdateData.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("Type {PropertyName} does not exist");

            RuleFor(p => p.Id)
            .NotNull()
            .WithMessage("{PropertyName} must be present")
            .MustAsync(LeaveAllocationMustExist)
            .WithMessage("Allocation id {PropertyName} does not exist");
        }

        private async Task<bool> LeaveAllocationMustExist(int id, CancellationToken token)
        {
            var leaveAllocationCheck = await _leaveAllocationRepository.GetByIdAsync(id);
            return leaveAllocationCheck != null;
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken)
        {
            var leaveTypeCheck = await _leaveTypeRepository.GetByIdAsync(id);
            return leaveTypeCheck != null;
        }
    }
}