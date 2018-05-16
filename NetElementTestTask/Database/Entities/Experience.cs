using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetElementTestTask.Database.Entities
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        public string ExpirienceDescription { get; set; }

        public int? CollaboratorId { get; set; }

        [ForeignKey("CollaboratorId")]
        public Collaborator Collaborator { get; set; }

        public int? ProgrammingLanguageId { get; set; }

        [ForeignKey("ProgrammingLanguageId")]
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
