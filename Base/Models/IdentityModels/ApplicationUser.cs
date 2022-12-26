using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.DataModels;
using Models.UtilityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = SD.DefaultName;
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        
        [ValidateNever]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public DateTime DateCreated { get; set; }
        [NotMapped]
        public string? RoleId { get; set; }
        [NotMapped]
        public string? Role { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? RoleList { get; set; }
    }
}