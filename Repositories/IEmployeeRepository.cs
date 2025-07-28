using CompanyApp.Model;

namespace CompanyApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee emp);
        Task<Employee> UpdateAsync(Employee emp);
        Task<bool> DeleteAsync(int id);
    }
}
