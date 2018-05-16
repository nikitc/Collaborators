using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetElementTestTask.Database.Entities
{
    public class ProgrammingLanguage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Experience> Experiences { get; set; }
    }
}
