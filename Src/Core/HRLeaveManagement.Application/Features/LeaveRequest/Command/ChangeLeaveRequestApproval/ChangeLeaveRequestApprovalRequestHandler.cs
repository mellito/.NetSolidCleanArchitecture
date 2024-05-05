using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalRequestHandler : IRequestHandler<ChangeLeaveRequestApprovalRequest, Unit>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<ChangeLeaveRequestApprovalRequestHandler> _appLogger;

        public ChangeLeaveRequestApprovalRequestHandler(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender, IAppLogger<ChangeLeaveRequestApprovalRequestHandler> appLogger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalRequest request, CancellationToken cancellationToken)
        {
            var validator = new ChangeLeaveRequestApprovalRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid leave request", validationResult);
            }
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            leaveRequest.Approved = request.LeaveRequestDto.Approved;

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,
                    Body = $"The approval status for you leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate}:D" + $"has been updated successfully",
                    Subject = "Leave Request Approval Status Updated"
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