using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KeenSap.Portal.Data.Entities;

namespace KeenSap.Portal.Service.Dto.Request
{
    public class UserUpdateDto : IDto
    {
        [Required]
        [StringLength(30,  ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }   
    }
}
