
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    [Table("roles")]
    public class Role : TrackableEntity
    {
        [Required]
        [StringLength(50,  ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Role Name")]
        [Column("name", Order = 6)]
        public string Name { get; set; }
    }
}