using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public class GetLeaveTypeQueryRequestHandler : IRequestHandler<GetLeaveTypeQueryRequest, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeQueryRequestHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQueryRequest request, CancellationToken cancellationToken)
        {   //query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            // conver data objects to dto objects
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            // return list of DTO object
            return data;
        }
    }
}