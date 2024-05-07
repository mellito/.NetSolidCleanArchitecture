using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Identity;
using HRLeaveManagement.Application.Models.Identity;
using HRLeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace HRLeaveManagement.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Employee> GetEmployee(string id)
        {
            var Employee = await _userManager.FindByEmailAsync(id);
            return new Employee
            {
                Email = Employee.Email,
                FirstName = Employee.FirstName,
                LastName = Employee.LastName,
                Id = Employee.Id
            };
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new Employee
            {
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName,
                Id = q.Id
            }).ToList();
        }
    }
}