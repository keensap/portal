using System.ComponentModel.DataAnnotations;

namespace KeenSap.Portal.Service.Dto.Request
{
  public class CredentialDto {
    [Required]
    [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
    [Display(Name = "Username")]
    public string username { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string password { get; set; }
  }
}