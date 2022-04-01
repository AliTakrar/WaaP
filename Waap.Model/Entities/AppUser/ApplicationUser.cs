
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Waap.Model.Entities.AppUser
{
    public class ApplicationUser : IdentityUser<long>
    {
        [MaxLength(450)]
        public string FullName { get; set; }
        public DateTimeOffset CreateDateTime { get; set; }

    }
}
