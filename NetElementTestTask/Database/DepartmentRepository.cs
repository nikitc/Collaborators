using System.Linq;
using NetElementTestTask.Database.Entities;
using NetElementTestTask.Database.Interfaces;

namespace NetElementTestTask.Database
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CollaboratorContext _context;

        public DepartmentRepository(CollaboratorContext context)
        {
            _context = context;
        }

        public IQueryable<Department> GetAll()
        {
            return _context.Departments;
        }
    }
}