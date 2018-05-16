using Microsoft.EntityFrameworkCore;
using NetElementTestTask.Database.Entities;

namespace NetElementTestTask.Database
{
    public class CollaboratorContext : DbContext
    {
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<NameInfo> NameInfos { get; set; }

        public CollaboratorContext(DbContextOptions<CollaboratorContext> options) : base(options)
        {
        }
    }
}
