using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequestDetailRequestValidator : AbstractValidator<GetLeaveRequestDetailRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public GetLeaveRequestDetailRequestValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            RuleFor(request => request.Id)
            .GreaterThan(0)
            .MustAsync(LeaveRequestMustExist);
        }

        private async Task<bool> LeaveRequestMustExist(int id, CancellationToken token)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveRequest != null;
        }
    }
}