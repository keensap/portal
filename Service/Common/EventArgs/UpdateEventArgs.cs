
using KeenSap.Portal.Service.Dto;

namespace KeenSap.Portal.Service.Common.EventArgs
{
    public class UpdateEventArgs<T> : System.EventArgs
    {
        public UpdateEventArgs(T entity, long id){
            this.Entity = entity;
            this.Id = id;
        }
        public T Entity { get; set; }
        public long Id { get; set; }
    }
}