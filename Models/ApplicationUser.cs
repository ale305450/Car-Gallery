using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Learing_Core.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required,MaxLength(100)]
        public string? FirstName { get; set; }

        [Required, MaxLength(100)]
        public string? LastName { get; set; }
        public byte[]? ProfilePic { get; set; }

    }
}
