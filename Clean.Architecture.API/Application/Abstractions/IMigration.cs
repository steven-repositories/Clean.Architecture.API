namespace Clean.Architecture.API.Application.Abstractions {
    public interface IMigration {
        void ExecuteMigrations(IHost host);
    }
}
