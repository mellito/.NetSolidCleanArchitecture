using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository<T> : IGenericRepository<LeaveAllocation>
    {
    }
}