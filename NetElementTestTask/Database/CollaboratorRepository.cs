using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetElementTestTask.Database.Entities;
using NetElementTestTask.Database.Interfaces;

namespace NetElementTestTask.Database
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly CollaboratorContext _context;

        public CollaboratorRepository(CollaboratorContext context)
        {
            _context = context;
        }

        public Collaborator GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Collaborator> GetAll()
        {
            return _context.Collaborators
                .Include(x => x.Department)
                .Include(x => x.Experience)
                        .ThenInclude(x => x.ProgrammingLanguage);
        }

        public void Create(Collaborator entity)
        {
            _context.Collaborators.Add(entity);
        }

        public void Update(Collaborator entity)
        {
            _context.Collaborators.Update(entity);
        }

        public void Delete(Collaborator entity)
        {
            _context.Collaborators.Remove(entity);
        }
    }
}