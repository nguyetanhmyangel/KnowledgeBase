using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("Comments")]
    public class Comment : AuditableBaseEntity<int>
    {
        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        [Required]
        public int KnowledgeId { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}