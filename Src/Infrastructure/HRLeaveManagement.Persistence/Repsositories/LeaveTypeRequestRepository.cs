using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Repsositories
{
    public class LeaveTypeRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveTypeRequestRepository(HRDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            return await _context.LeaveRequests.Include(q => q.LeaveType).AsNoTracking().ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            return await _context.LeaveRequests.Where(request => request.RequestingEmployeeId == userId).Include(q => q.LeaveType).AsNoTracking().ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            return await _context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(request => request.Id == id);
        }
    }
}