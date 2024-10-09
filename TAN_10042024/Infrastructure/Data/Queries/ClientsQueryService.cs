using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class ClientsQueryService : IClientsQueryService {
        private readonly ILogger<ClientsQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public ClientsQueryService(ILogger<ClientsQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<Clients?> GetClientByName(string clientName) {
            return _dbContext
                .Set<Clients>()
                .Where(client => client.Name == clientName)
                .FirstOrDefaultAsync();
        }
    }
}
