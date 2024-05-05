using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationRequestHandler : IRequestHandler<CreateLeaveAllocationRequest, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationRequestHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationRequestValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                throw new BadRequestException("Invalid leave allocation request", validationResult);
            }

            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.CreateData.LeaveTypeId);
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateData);
            await _leaveAllocationRepository.CreateAsync(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}