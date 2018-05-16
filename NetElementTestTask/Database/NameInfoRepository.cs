using System.Linq;
using NetElementTestTask.Database.Entities;
using NetElementTestTask.Database.Interfaces;

namespace NetElementTestTask.Database
{
    public class NameInfoRepository : INameInfoRepository
    {
        private readonly CollaboratorContext _context;

        public NameInfoRepository(CollaboratorContext context)
        {
            _context = context;
        }

        public IQueryable<NameInfo> GetAll()
        {
            return _context.NameInfos;
        }
    }
}