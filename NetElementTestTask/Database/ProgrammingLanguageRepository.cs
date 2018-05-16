using System.Linq;
using NetElementTestTask.Database.Entities;
using NetElementTestTask.Database.Interfaces;

namespace NetElementTestTask.Database
{
    public class ProgrammingLanguageRepository : IProgrammingLanguageRepository
    {

        private readonly CollaboratorContext _context;

        public ProgrammingLanguageRepository(CollaboratorContext context)
        {
            _context = context;
        }

        public IQueryable<ProgrammingLanguage> GetAll()
        {
            return _context.ProgrammingLanguages;
        }
    }
}
