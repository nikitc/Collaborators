using System.Linq;
using NetElementTestTask.Database.Entities;

namespace NetElementTestTask.Database.Interfaces
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> GetAll();
    }
}
