

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Waap.Model.Entities.AppUser
{
    public class ApplicationRole : IdentityRole<long>
    {
        [MaxLength(450)]
        public string Description { get; set; }
        public DateTimeOffset CreateDateTime { get; set; }
    }
}
