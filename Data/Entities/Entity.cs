using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    public abstract class Entity : IEntity
    {
        [Key]
        [Column("id", Order = 1)]
        public long Id { get; set; }

        public virtual void copy(Entity entity){

        }
    }
}