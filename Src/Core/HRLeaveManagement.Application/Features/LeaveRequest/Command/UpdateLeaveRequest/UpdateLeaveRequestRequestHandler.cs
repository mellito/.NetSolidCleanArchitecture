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

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest
{
    public class UpdateLeaveRequestRequestHandler : IRequestHandler<UpdateLeaveRequestRequest, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<UpdateLeaveRequestRequestHandler> _appLogger;

        public UpdateLeaveRequestRequestHandler(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender, IAppLogger<UpdateLeaveRequestRequestHandler> appLogger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestRequestValidator(_leaveRequestRepository, _leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid leave request", validationResult);
            }
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            _mapper.Map(request.leaveRequestToUpdate, leaveRequest);

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,
                    Body = $"Your leave request for {request.leaveRequestToUpdate.StartDate:D} to {request.leaveRequestToUpdate.EndDate}:D" + $"has been updated successfully",
                    Subject = "Leave Request Submitted"
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