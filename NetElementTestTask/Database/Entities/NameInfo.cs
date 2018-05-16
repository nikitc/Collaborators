using System.ComponentModel.DataAnnotations;

namespace NetElementTestTask.Database.Entities
{
    public class NameInfo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
