using NetElementTestTask.Database.Interfaces;

namespace NetElementTestTask.Services
{
    public interface IDataManager
    {
        ICollaboratorRepository CollaboratorRepository { get; set; }
        IDepartmentRepository DepartmentRepository { get; set; }
        IProgrammingLanguageRepository ProgrammingLanguageRepository { get; set; }
        INameInfoRepository NameInfoRepository { get; set; }
        void SaveChanges();
    }
}
