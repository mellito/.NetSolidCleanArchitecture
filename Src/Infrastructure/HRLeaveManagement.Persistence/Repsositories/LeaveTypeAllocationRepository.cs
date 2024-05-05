using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Repsositories
{
    public class LeaveTypeAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveTypeAllocationRepository(HRDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations.Include(type => type.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations.Include(type => type.LeaveType).Where(allocation => allocation.EmployeeId == userId).ToListAsync();
            return leaveAllocations;
        }

        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            return _context.LeaveAllocations.Include(type => type.LeaveType).FirstOrDefaultAsync(allocation => allocation.Id == Id);
        }

        public Task<LeaveAllocation> GetUserAllocations(string userId, int LeaveTypeId)
        {
            return _context.LeaveAllocations.FirstOrDefaultAsync(allocation => allocation.EmployeeId == userId && allocation.LeaveTypeId == LeaveTypeId);
        }
    }
}