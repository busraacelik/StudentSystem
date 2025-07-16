using Microsoft.AspNetCore.Identity;

namespace StudentSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? FullName { get; set; }
        public string? Parola { get; set; }
        public string? PhoneNumber { get; set; }
       
    }
    
    }

