using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities
{
    public abstract class Schema : ISchema {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        [NotMapped]
        public bool IsNew { get; private set; }

        public Schema() {
            CreatedDateTime = DateTime.Now;
            IsNew = Id == default;
        }
    }
}
