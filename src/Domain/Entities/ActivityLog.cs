using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("ActivityLogs")]
    public class ActivityLog : AuditableBaseEntity<int>
    {

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Action { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string EntityName { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string EntityId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string UserId { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }
    }
}