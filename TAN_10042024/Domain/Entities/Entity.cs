using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public abstract class Entity : IEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }
        public DateTime CreatedDateTime { get; private set; }

        [NotMapped]
        public bool IsNew { get; private set; }

        public Entity() {
            CreatedDateTime = DateTime.Now;
            IsNew = Id == default;
        }
    }
}
