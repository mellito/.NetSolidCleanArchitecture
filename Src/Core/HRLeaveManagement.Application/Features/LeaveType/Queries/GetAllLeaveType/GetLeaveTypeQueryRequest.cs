using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public class GetLeaveTypeQueryRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}