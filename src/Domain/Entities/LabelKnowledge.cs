using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("LabelKnowledge")]
    public class LabelKnowledge : AuditableBaseEntity<int>
    {
        public int KnowledgeId { get; set; }

        public int LabelId { get; set; }

        public virtual Knowledge Knowledge{ get; set; }

        public virtual Label Label { get; set; }
    }
}