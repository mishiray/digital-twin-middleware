using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.DTOs
{
    public class GenerateRefreshTokenDto
    {
        [Required]
        public string CurrentJWT { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
