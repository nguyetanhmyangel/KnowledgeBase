using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("Votes")]
    public class Vote : AuditableEntity<int>
    {
        public int KnowledgeId { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}