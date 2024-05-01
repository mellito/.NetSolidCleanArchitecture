using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveLeaveRequest<T> : IGenericRepository<LeaveRequest>
    {
    }
}