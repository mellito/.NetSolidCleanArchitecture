using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.DeleteLeaveRequest
{
    public class DeleteLeaveRequestRequestHandler : IRequestHandler<DeleteLeaveRequestRequest, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestRequest request, CancellationToken cancellationToken)
        {

            var validator = new DeleteLeaveRequestRequestValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                throw new BadRequestException("Invalid leave allocation request", validationResult);
            }
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            _leaveRequestRepository.DeleteAsync(leaveRequest);
            return Unit.Value;
        }
    }
}