using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    public abstract class SoftDeletableEntity : TrackableEntity, ISoftDeletable
    {
        [Column("is_deleted", Order = 6)]
        public bool IsDeleted { get; set; }
    }
}