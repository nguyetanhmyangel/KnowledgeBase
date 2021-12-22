using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;

namespace Domain.Entities
{
    // Like Command
    [Table("AppCommands")]
    public class AppCommand : AuditableBaseEntity<int>
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}