namespace TAN_10042024.Application.Abstractions {
    public interface IPersonService {
        int GetMaxScoreByTeam(string team);
        int GetSecondToLeastScoreByTeam(string team);
        string UnionizePersonNamesByTeam(string team);
    }
}
