using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    [Table("Attachments")]
    public class Attachment : AuditableEntity<int>
    {
        [Required]
        [MaxLength(200)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(200)]
        public string FilePath { get; set; }

        [Required]
        [MaxLength(4)]
        [Column(TypeName = "varchar(4)")]
        public string FileType { get; set; }

        [Required]
        public long FileSize { get; set; }

        public int? KnowledgeBaseId { get; set; }

        public int? CommentId { get; set; }

        public virtual Knowledge Knowledge { get; set; }

        public virtual Comment Comment { get; set; }
    }
}