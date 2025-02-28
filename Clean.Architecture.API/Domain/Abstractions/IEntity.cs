namespace Clean.Architecture.API.Domain.Abstractions {
    public interface IEntity {
        int Id { get; }
        DateTime CreatedDateTime { get; }
    }
}
