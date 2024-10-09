namespace TAN_10042024.Application.Abstractions.Controllers {
    public interface IPersonService {
        Task<int> GetMaxScoreByTeam(string team);
        Task<int> GetSecondToLeastScoreByTeam(string team);
        Task<string> UnionizePersonNamesByTeam(string team);
    }
}
