using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("AppCommandFunctions")]
    public class AppCommandFunction : AuditableBaseEntity<int>
    {
        public int AppCommandId { get; set; }

        public int FunctionId { get; set; }

        public virtual AppCommand AppCommand { get; set; }

        public virtual Function Function { get; set; }
    }
}