using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Application.Abstractions.Queries;
using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Infrastructure.Data.Queries {
    public class ClientQueryService : IClientQueryService {
        private readonly ILogger<ClientQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public ClientQueryService(ILogger<ClientQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<Client?> GetClientByName(string clientName) {
            return _dbContext
                .Set<Client>()
                .Where(client => client.Name == clientName)
                .FirstOrDefaultAsync();
        }
    }
}
