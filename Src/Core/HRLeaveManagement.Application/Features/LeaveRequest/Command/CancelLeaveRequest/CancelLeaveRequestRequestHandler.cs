using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.CancelLeaveRequest
{
    public class CancelLeaveRequestRequestHandler : IRequestHandler<CancelLeaveRequestRequest, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CancelLeaveRequestRequestHandler> _appLogger;
        public CancelLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender, IAppLogger<CancelLeaveRequestRequestHandler> appLogger)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }

        public async Task<Unit> Handle(CancelLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var validator = new CancelLeaveRequestRequestValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid leave request", validationResult);
            }
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            leaveRequest.Cancelled = true;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,
                    Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate}:D" + $"has been updated successfully",
                    Subject = "Leave Request Cancelled"
                };
                await _emailSender.SendEmailAsync(email);
            }
            catch (System.Exception ex)
            {
                _appLogger.LogWarning(ex.Message);
                throw;
            }
            return Unit.Value;
        }
    }
}