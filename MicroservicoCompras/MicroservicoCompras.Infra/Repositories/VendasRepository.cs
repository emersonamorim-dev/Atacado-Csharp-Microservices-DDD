using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using MicroservicoCompras.Infra.Data;
using MicroservicoCompras.Domain.Entities;
using MicroservicoCompras.Infra.Interfaces;

namespace MicroservicoCompras.Infra.Repositories
{
    public class VendasRepository : IVendasRepository
    {
        private readonly IMongoCollection<Venda> _vendasCollection;

        public VendasRepository(IOptions<VendasDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _vendasCollection = mongoDatabase.GetCollection<Venda>(settings.Value.CollectionName);
        }

        public async Task<List<Venda>> GetVendaAsync() =>
            await _vendasCollection.Find(x => true).ToListAsync();

        public async Task<Venda> CreateVendaAsync(Venda venda)
        {
            await _vendasCollection.InsertOneAsync(venda);

            return venda;
        }

        public async Task DeleteVendaAsync(string vendaId)
        {
            await _vendasCollection.DeleteOneAsync(x => x.Id == vendaId);
        }

        public async Task<Venda> UpdateVendaAsync(Venda venda)
        {
            await _vendasCollection.ReplaceOneAsync(x => x.Id == venda.Id, venda);
            return venda;
        }
    }
}
