
using KeenSap.Portal.Service.Dto;

namespace KeenSap.Portal.Service.Common.EventArgs
{
    public class CreateEventArgs<T> : System.EventArgs
    {
        public CreateEventArgs(T entity){
            this.Entity = entity;
        }
        public T Entity { get; set; }
    }
}