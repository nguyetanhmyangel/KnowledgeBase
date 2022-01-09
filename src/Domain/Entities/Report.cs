using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("Reports")]
    public class Report :AuditableEntity<int>
    {
        public int KnowledgeId { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsProcessed { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}