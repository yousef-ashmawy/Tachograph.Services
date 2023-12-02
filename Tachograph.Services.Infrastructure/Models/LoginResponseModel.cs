

using System.Text.Json.Serialization;

namespace Tachograph.Services.Infrastructure.Models
{
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string? email { get; set; }
        public string? Token { get; set; }
    }
}
