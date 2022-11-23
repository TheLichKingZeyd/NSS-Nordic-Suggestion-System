using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace NordicDoorSuggestionSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public Department? GetDepartmentByID(int departmentID)
        {
            return _context.Departments.FirstOrDefault(x => x.DepartmentID == departmentID);
        }

        public async Task<Department> GetDepartment(int? departmentID)
        {
            if (departmentID == null)
                throw new NullReferenceException("DepartmentID can not be null");

            var department = await _context.Departments.FindAsync(departmentID);

            if (department == null)
                return null;

            return department;
        }

        public Task<List<Department>> GetDepartments()
        {
            return _context.Departments.ToListAsync();
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public async Task Delete(Department department)
        {
            _context.Departments.Remove(department);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Department department)
        {
            _context.Departments.Update(department);
        }
    }
}
