namespace Hospital.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string LastName { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
