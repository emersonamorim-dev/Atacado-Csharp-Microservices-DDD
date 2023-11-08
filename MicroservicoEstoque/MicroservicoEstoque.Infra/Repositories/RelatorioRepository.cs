using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly IMongoCollection<Relatorio> _relatorioCollection;

        public RelatorioRepository(IOptions<RelatorioDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _relatorioCollection = mongoDatabase.GetCollection<Relatorio>(settings.Value.CollectionName);
        }

        public async Task<List<Relatorio>> GetRelatorioAsync() =>
            await _relatorioCollection.Find(x => true).ToListAsync();

        public async Task<Relatorio> CreateRelatorioAsync(Relatorio relatorio)
        {
            await _relatorioCollection.InsertOneAsync(relatorio);
            return relatorio;
        }

        public async Task<Relatorio> UpdateRelatorioAsync(Relatorio relatorio)
        {
            await _relatorioCollection.ReplaceOneAsync(x => x.Id == relatorio.Id, relatorio);
            return relatorio;
        }

        public async Task DeleteRelatorioAsync(string relatorioId)
        {
            await _relatorioCollection.DeleteOneAsync(x => x.Id == relatorioId);
        }
    }
}
