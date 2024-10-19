namespace TAN_10042024.Application.Abstractions {
    public interface IMigration {
        void ExecuteMigrations(IHost host);
    }
}
