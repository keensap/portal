using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    [Table("users")]
    public class User : SoftDeletableEntity
    {
        public User()
        {
            IsActive = true;
        }

        [Required]
        [StringLength(30,  ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [Column("first_name", Order = 7)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(30,  ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [Column("last_name", Order = 8)]
        public string LastName { get; set; }
        
        
        [Required]
        [Display(Name = "Is Active")]
        [Column("is_active", Order = 9)]
        public bool IsActive { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100,  ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        [Column("email", Order = 10)]
        public string Email { get; set; }   

        [Required]
        [StringLength(100,  ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [Column("username", Order = 11)]
        public string Username { get; set; }   
        

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Column("password", Order = 12)]
        public string Password { get; set; }

        [Column("salt", Order = 13)]
        public string Salt { get; set; }

        [Column("token", Order = 14)]
        public string Token { get; set; }



        [InverseProperty("User")]
        public virtual ICollection<UserRole> UserRoles { get; set; }


        public override void copy(Entity entity){
            var user = (User)entity;
            
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.IsActive = user.IsActive;
        }

        // public enum UserTypeEnum{
        //     Admin = 0,
        //     Editor = 1,
        //     AssistantEditor = 2,
        //     Author = 3,
        //     Reviewer = 4
        // }

        
        // public string Role { get; set; }
    }
}