using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.MappingProfile
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<GetLeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, GetLeaveAllocationDetailDto>();
            CreateMap<UpdateAllocationDto, LeaveAllocation>();
            CreateMap<CreateLeaveAllocationDto, LeaveAllocation>();
        }
    }
}