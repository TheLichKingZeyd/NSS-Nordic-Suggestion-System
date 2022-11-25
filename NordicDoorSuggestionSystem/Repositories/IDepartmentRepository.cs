using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface IDepartmentRepository
    {
        Department GetDepartmentByID(int departmentID);
        Task<Department> GetDepartment(int? departmentID);
        Task<List<Department>> GetDepartments();
        public void Add(Department department);
        Task Delete(Department department);
        Task SaveChanges();
        Task Update(Department department);
    }
}
