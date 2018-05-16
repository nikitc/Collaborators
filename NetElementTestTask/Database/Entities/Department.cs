using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetElementTestTask.Database.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public virtual List<Collaborator> Collaborators { get; set; }
    }
}
