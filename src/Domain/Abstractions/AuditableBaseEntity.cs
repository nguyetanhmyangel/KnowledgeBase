using System.ComponentModel.DataAnnotations;

namespace Domain.Abstractions
{
    public abstract class AuditableBaseEntity<T> : IAuditableBaseEntity, IBaseEntity<T> //where T : struct
    {
        public T Id { get; set; }

        public DateTime CreateDate { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [MaxLength(50)]
        public string LastModifiedBy { get; set; }

        //public bool IsTransient()
        //{
        //    throw new NotImplementedException();
        //}
    }
}