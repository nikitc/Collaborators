using NetElementTestTask.Database;
using NetElementTestTask.Database.Interfaces;

namespace NetElementTestTask.Services
{
    public class DataManager : IDataManager
    {
        private readonly CollaboratorContext _context;

        public DataManager(CollaboratorContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ICollaboratorRepository CollaboratorRepository
        {
            get => _collaboratorRepository ?? (_collaboratorRepository = new CollaboratorRepository(_context));
            set { }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get => _departmentRepository ?? (_departmentRepository = new DepartmentRepository(_context));
            set { }
        }

        public IProgrammingLanguageRepository ProgrammingLanguageRepository
        {
            get => _programmingLanguageRepository ?? (_programmingLanguageRepository = 
                new ProgrammingLanguageRepository(_context));
            set { }
        }

        public INameInfoRepository NameInfoRepository
        {
            get => _nameInfoRepository ?? (_nameInfoRepository = new NameInfoRepository(_context));
            set { }
        }

        private CollaboratorRepository _collaboratorRepository { get; set; }
        private DepartmentRepository _departmentRepository { get; set; }
        private ProgrammingLanguageRepository _programmingLanguageRepository { get; set; }
        private NameInfoRepository _nameInfoRepository { get; set; }
    }
}
