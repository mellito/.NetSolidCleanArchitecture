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

namespace HRLeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest
{
    public class CreateLeaveRequestRequestHandler : IRequestHandler<CreateLeaveRequestRequest, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CreateLeaveRequestRequestHandler> _appLogger;

        public CreateLeaveRequestRequestHandler(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender, IAppLogger<CreateLeaveRequestRequestHandler> appLogger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(CreateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestRequestValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid leave request", validationResult);
            }
            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.LeaveRequestDto);
            await _leaveRequestRepository.CreateAsync(leaveRequest);
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,
                    Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate}:D" + $"has been updated successfully",
                    Subject = "Leave Request Submitted"
                };
                await _emailSender.SendEmailAsync(email);
            }
            catch (System.Exception ex)
            {
                _appLogger.LogWarning(ex.Message);
                throw;
            }
            return leaveRequest.Id;
        }
    }
}