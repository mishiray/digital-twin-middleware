using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities.Component
{
    public class BaseEntity : DbEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
