using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public class GetLeaveTypeQueryRequestHandler : IRequestHandler<GetLeaveTypeQueryRequest, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypeQueryRequestHandler> _logger;
        public GetLeaveTypeQueryRequestHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypeQueryRequestHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQueryRequest request, CancellationToken cancellationToken)
        {   //query the database
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            // conver data objects to dto objects
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            // return list of DTO object
            _logger.LogInformation("Leave types were retrieved successfully");
            return data;
        }
    }
}