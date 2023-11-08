using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class ControleQualidadeRepository : IControleQualidadeRepository
    {
        private readonly IMongoCollection<ControleQualidade> _controleQualidadeCollection;

        public ControleQualidadeRepository(IOptions<ControleQualidadeDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _controleQualidadeCollection = mongoDatabase.GetCollection<ControleQualidade>(settings.Value.CollectionName);
        }

        public async Task<List<ControleQualidade>> GetControleQualidadeAsync() =>
            await _controleQualidadeCollection.Find(x => true).ToListAsync();

        public async Task<ControleQualidade> CreateControleQualidadeAsync(ControleQualidade controleQualidade)
        {
            await _controleQualidadeCollection.InsertOneAsync(controleQualidade);
            return controleQualidade;
        }

        public async Task<ControleQualidade> UpdateControleQualidadeAsync(ControleQualidade controleQualidade)
        {
            await _controleQualidadeCollection.ReplaceOneAsync(x => x.Id == controleQualidade.Id, controleQualidade);
            return controleQualidade;
        }

        public async Task DeleteControleQualidadeAsync(string controleQualidadeId)
        {
            await _controleQualidadeCollection.DeleteOneAsync(x => x.Id == controleQualidadeId);
        }
    }
}
