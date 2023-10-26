using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanning.Model
{
    public class Root
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public bool Edit { get; set; }
    }
}