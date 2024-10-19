namespace TAN_10042024.Domain.Abstractions {
    public interface IEntity {
        int Id { get; }
        DateTime CreatedDateTime { get; }
    }
}
