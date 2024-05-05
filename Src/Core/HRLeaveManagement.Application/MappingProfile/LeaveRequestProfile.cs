using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.MappingProfile
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestDetailDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, LeaveRequest>();
            CreateMap<UpdateLeaveRequestDto, LeaveRequest>();
        }
    }
}