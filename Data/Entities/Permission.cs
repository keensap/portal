using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    [Table("permissions")]
    public class Permission: Entity
    {
        [Required]
        [Column("role_id", Order = 2)]
        public long RoleId { get; set; }

        [Required]
        [Column("entity_action_id", Order = 2)]
        public long EntityActionId { get; set; }

        [ForeignKey("EntityActionId")]
        public EntityAction EntityAction { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public string getEntityActionName() => EntityAction.getEntityActionName();

        public Security.EntityEnum getEntityName() => EntityAction.getEntityName();
        public Security.ActionEnum getActionName() => EntityAction.getActionName();
    }
}
