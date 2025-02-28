namespace Clean.Architecture.API.Application.Abstractions {
    public interface IPerson {
        Task<int?> GetMaxScoreByTeam(string team);
        Task<int?> GetSecondToLeastScoreByTeam(string team);
        Task<string> UnionizePersonNamesByTeam(string team);
    }
}
