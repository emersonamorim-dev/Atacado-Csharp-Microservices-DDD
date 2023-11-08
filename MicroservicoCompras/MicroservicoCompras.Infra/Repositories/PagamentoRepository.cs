using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;
using MongoDB.Driver;
using MicroservicoCompras.Infra.Interfaces;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using MicroservicoCompras.Infra.Data;

namespace MicroservicoCompras.Infra.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly IMongoCollection<Pagamento> _pagamentosCollection;

        public PagamentoRepository(IOptions<PagamentosDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _pagamentosCollection = mongoDatabase.GetCollection<Pagamento>(settings.Value.CollectionName);
        }

        public async Task<List<Pagamento>> GetPagamentoAsync() =>
            await _pagamentosCollection.Find(x => true).ToListAsync();

        public async Task<Pagamento> CreatePagamentoAsync(Pagamento pagamento)
        {
            await _pagamentosCollection.InsertOneAsync(pagamento);

            return pagamento;
        }

        public async Task DeletePagamentoAsync(string pagamentoId)
        {
            await _pagamentosCollection.DeleteOneAsync(x => x.Id == pagamentoId);
        }

        public async Task<Pagamento> UpdatePagamentoAsync(Pagamento pagamento)
        {
            await _pagamentosCollection.ReplaceOneAsync(x => x.Id == pagamento.Id, pagamento);
            return pagamento;
        }
    }
}

