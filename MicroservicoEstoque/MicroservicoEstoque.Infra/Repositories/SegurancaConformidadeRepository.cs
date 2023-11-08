using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class SegurancaConformidadeRepository : ISegurancaConformidadeRepository
    {
        private readonly IMongoCollection<SegurancaConformidade> _segurancaConformidadeCollection;

        public SegurancaConformidadeRepository(IOptions<SegurancaConformidadeDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _segurancaConformidadeCollection = mongoDatabase.GetCollection<SegurancaConformidade>(settings.Value.CollectionName);
        }

        public async Task<List<SegurancaConformidade>> GetSegurancaConformidadeAsync() =>
            await _segurancaConformidadeCollection.Find(x => true).ToListAsync();

        public async Task<SegurancaConformidade> CreateSegurancaConformidadeAsync(SegurancaConformidade segurancaConformidade)
        {
            await _segurancaConformidadeCollection.InsertOneAsync(segurancaConformidade);
            return segurancaConformidade;
        }

        public async Task<SegurancaConformidade> UpdateSegurancaConformidadeAsync(SegurancaConformidade segurancaConformidade)
        {
            await _segurancaConformidadeCollection.ReplaceOneAsync(x => x.Id == segurancaConformidade.Id, segurancaConformidade);
            return segurancaConformidade;
        }

        public async Task DeleteSegurancaConformidadeAsync(string segurancaConformidadeId)
        {
            await _segurancaConformidadeCollection.DeleteOneAsync(x => x.Id == segurancaConformidadeId);
        }
    }
}
