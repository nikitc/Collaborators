using System.Linq;
using NetElementTestTask.Database.Entities;

namespace NetElementTestTask.Database.Interfaces
{
    public interface IProgrammingLanguageRepository
    {
        IQueryable<ProgrammingLanguage> GetAll();
    }
}
