using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenSap.Portal.Data.Entities
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        long? CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        long? UpdatedBy { get; set; }
    }
}
