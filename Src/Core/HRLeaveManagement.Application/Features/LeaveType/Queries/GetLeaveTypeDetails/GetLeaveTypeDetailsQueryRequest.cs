using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryRequest : IRequest<LeaveTypeDetailsDto>
    {
        public int Id { get; set; }
        public GetLeaveTypeDetailsQueryRequest(int id)
        {
            this.Id = id;

        }


    }
}