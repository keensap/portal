using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    [Table("user_roles")]
    public class UserRole : Entity
    {
        [Required]
        [Column("role_id", Order = 2)]
        public long RoleId { get; set; }

        [Required]
        [Column("user_id", Order = 3)]
        public long UserId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
