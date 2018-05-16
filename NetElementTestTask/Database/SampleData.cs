using System.Linq;
using NetElementTestTask.Database.Entities;

namespace NetElementTestTask.Database
{
    public class SampleData
    {
        public static void Initialize(CollaboratorContext context)
        {
            if (!context.ProgrammingLanguages.Any() || !context.Departments.Any() || !context.NameInfos.Any())
            {
                context.ProgrammingLanguages.AddRange(
                    new ProgrammingLanguage { Name = "C#" },
                    new ProgrammingLanguage { Name = "Python" },
                    new ProgrammingLanguage { Name = "Kotlin" }
                );

                context.Departments.AddRange(
                    new Department { Name = "Aptito", Floor = 7},
                    new Department { Name = "PayOnline", Floor = 1},
                    new Department { Name = "RestoActive", Floor = 2}
                );

                context.NameInfos.AddRange(
                    new NameInfo { Name = "Наталья"},
                    new NameInfo { Name = "Игорь"},
                    new NameInfo { Name = "Евгений"},
                    new NameInfo { Name = "Олег"},
                    new NameInfo { Name = "Ирина"},
                    new NameInfo { Name = "Никита"},
                    new NameInfo { Name = "Станислав"},
                    new NameInfo { Name = "Иван"},
                    new NameInfo { Name = "Дмитрий"}
                );

                context.SaveChanges();
            }
        }
    }
}
