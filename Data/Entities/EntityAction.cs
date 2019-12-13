using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    [Table("entity_actions")]
    public class EntityAction : Entity
    {
        [Required]
        [Column("entity_id", Order = 2)]
        public int EntityId { get; set; }

        [Required]
        [Column("action_id", Order = 3)]
        public int ActionId { get; set; }

        [InverseProperty("EntityAction")]
        public virtual ICollection<Permission> Permissions { get; set; }

        public string getEntityActionName() => ((Security.EntityEnum)EntityId).ToString() + "_" + ((Security.ActionEnum)ActionId).ToString();

        public Security.EntityEnum getEntityName() => (Security.EntityEnum)EntityId;
        public Security.ActionEnum getActionName() => (Security.ActionEnum)ActionId;
    }
}
