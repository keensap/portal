using System;

namespace KeenSap.Portal.Data.Entities
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
