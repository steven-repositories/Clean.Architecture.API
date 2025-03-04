using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.Architecture.API.Domain.Abstractions {
    public abstract class Entity {
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
