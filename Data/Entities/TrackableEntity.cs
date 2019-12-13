using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    public abstract class TrackableEntity : Entity, ITrackable
    {
        public TrackableEntity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created At")]
        [Column("created_at", Order = 2)]
        public DateTime CreatedAt { get; set; }
        
        [Column("created_by", Order = 3)]
        public long? CreatedBy { get; set; }
        
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Update At")]
        [Column("updated_at", Order = 4)]
        public DateTime UpdatedAt { get; set; }
        
        [Column("updated_by", Order = 5)]
        public long? UpdatedBy { get; set; }
    }
}
