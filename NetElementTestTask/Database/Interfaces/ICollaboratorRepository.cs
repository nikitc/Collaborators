using System.Linq;
using NetElementTestTask.Database.Entities;

namespace NetElementTestTask.Database.Interfaces
{
    public interface ICollaboratorRepository
    {
        Collaborator GetById(int id);
        IQueryable<Collaborator> GetAll();
        void Create(Collaborator entity);
        void Update(Collaborator entity);
        void Delete(Collaborator entity);
    }
}
