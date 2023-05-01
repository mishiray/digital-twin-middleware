using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalTwinMiddleware.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        public string RoleName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
