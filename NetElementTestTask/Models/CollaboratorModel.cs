using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetElementTestTask.Database.Entities;
using NetElementTestTask.Services;

namespace NetElementTestTask.Models
{
    public class CollaboratorModel : IValidatableObject
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }


        [Required(ErrorMessage = "Возраст обязателен для заполнения")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Не указано пол")]
        [Display(Name = "Пол")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Не указан опыт работы")]
        [Display(Name = "Опыт работы")]
        public string Experience { get; set; }


        [Required(ErrorMessage = "Не указан отдел")]
        [Display(Name = "Отдел")]
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<SelectListItem> Depatments { get; set; }
        
        [Required(ErrorMessage = "Не указан язык программирования")]
        [Display(Name = "Язык программирования")]
        public string ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public List<SelectListItem> ProgrammingLanguages { get; set; }
        
        
        public void SetModel(Collaborator collaborator, IDataManager dataManager)
        {
            Id = collaborator.Id;
            FirstName = collaborator.FirstName;
            SecondName = collaborator.SecondName;
            MiddleName = collaborator.MiddleName;
            Age = collaborator.Age;
            Sex = collaborator.Sex;
            DepartmentId = collaborator.Department.Id.ToString();
            ProgrammingLanguageId = collaborator.Experience.ProgrammingLanguage.Id.ToString();
            Experience = collaborator.Experience.ExpirienceDescription;
            DepartmentName = $"{collaborator.Department.Name} {collaborator.Department.Floor} этаж";
            ProgrammingLanguageName = collaborator.Experience.ProgrammingLanguage.Name;
            FillItems(dataManager);
        }

        public void FillItems(IDataManager dataManager)
        {
            Depatments = dataManager.DepartmentRepository.GetAll()
                .Select(x => new SelectListItem { Text = x.Name + " " + x.Floor + " этаж", Value = x.Id.ToString() })
                .ToList();
            ProgrammingLanguages = dataManager.ProgrammingLanguageRepository.GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();
        }


        public void ApplyChanges(Collaborator collaborator)
        {
            collaborator.FirstName = FirstName;
            collaborator.SecondName = SecondName;
            collaborator.MiddleName = MiddleName;
            collaborator.Age = Age;
            collaborator.Sex = Sex;
            collaborator.DepartmentId = int.Parse(DepartmentId);
            if (Id == null)
            {
                var experience = new Experience
                {
                    ExpirienceDescription = Experience,
                    ProgrammingLanguageId = int.Parse(ProgrammingLanguageId),
                    CollaboratorId = collaborator.Id
                };
                collaborator.Experience = experience;
            }
            else
            {
                collaborator.Experience.ExpirienceDescription = Experience;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age < 18)
            {
                yield return new ValidationResult("Возраст сотрудника должен достигать 18 лет", new[] { nameof(Age) });
            }
        }
    }
}
