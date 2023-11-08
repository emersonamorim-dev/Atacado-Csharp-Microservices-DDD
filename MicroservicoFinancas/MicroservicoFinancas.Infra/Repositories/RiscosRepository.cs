using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using MicroservicoFinancas.Infra.Data;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MicroservicoFinancas.Infra.Repositories
{
    public class RiscosRepository : IRiscosRepository
    {
        private readonly IMongoCollection<Riscos> _riscosCollection;

        public RiscosRepository(IOptions<RiscosDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _riscosCollection = mongoDatabase.GetCollection<Riscos>(settings.Value.CollectionName);
        }

        public async Task<List<Riscos>> GetRiscosAsync() =>
            await _riscosCollection.Find(x => true).ToListAsync();

        public async Task<Riscos> CreateRiscosAsync(Riscos riscos)
        {
            await _riscosCollection.InsertOneAsync(riscos);
            return riscos;
        }

        public async Task DeleteRiscosAsync(string riscosId)
        {
            await _riscosCollection.DeleteOneAsync(x => x.Id == riscosId);
        }

        public async Task<Riscos> UpdateRiscosAsync(Riscos riscos)
        {
            await _riscosCollection.ReplaceOneAsync(x => x.Id == riscos.Id, riscos);
            return riscos;
        }
    }
}
