using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TAN_10042024.Domain.Abstractions {
    public abstract class Entity : IEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        [NotMapped]
        public bool IsNew { get; private set; }

        protected Entity() {
            CreatedDateTime = DateTime.Now;
            IsNew = Id == default;
        }
    }
}
