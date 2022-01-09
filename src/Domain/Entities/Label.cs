using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("Labels")]
    public class Label : AuditableEntity<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}