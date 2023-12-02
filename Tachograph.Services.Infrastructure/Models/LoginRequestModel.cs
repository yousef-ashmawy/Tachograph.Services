
using System.ComponentModel.DataAnnotations;


namespace Tachograph.Services.Infrastructure.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
