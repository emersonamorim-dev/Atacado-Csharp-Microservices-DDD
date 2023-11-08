using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using MicroservicoEstoque.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Infra.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IMongoCollection<Fornecedor> _fornecedorCollection;

        public FornecedorRepository(IOptions<FornecedorDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _fornecedorCollection = mongoDatabase.GetCollection<Fornecedor>(settings.Value.CollectionName);
        }

        public async Task<List<Fornecedor>> GetFornecedorAsync() =>
            await _fornecedorCollection.Find(x => true).ToListAsync();

        public async Task<Fornecedor> CreateFornecedorAsync(Fornecedor fornecedor)
        {
            await _fornecedorCollection.InsertOneAsync(fornecedor);
            return fornecedor;
        }

        public async Task<Fornecedor> UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            await _fornecedorCollection.ReplaceOneAsync(x => x.Id == fornecedor.Id, fornecedor);
            return fornecedor;
        }

        public async Task DeleteFornecedorAsync(string fornecedorId)
        {
            await _fornecedorCollection.DeleteOneAsync(x => x.Id == fornecedorId);
        }
    }
}
