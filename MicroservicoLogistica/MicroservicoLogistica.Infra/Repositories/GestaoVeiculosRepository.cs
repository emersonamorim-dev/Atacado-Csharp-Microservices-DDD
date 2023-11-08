using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;
using MicroservicoLogistica.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroservicoLogistica.Infra.Repositories
{
    public class GestaoVeiculosRepository : IGestaoVeiculosRepository
    {
        private readonly IMongoCollection<GestaoVeiculos> _gestaoVeiculosCollection;

        public GestaoVeiculosRepository(IOptions<GestaoVeiculosDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _gestaoVeiculosCollection = mongoDatabase.GetCollection<GestaoVeiculos>(settings.Value.CollectionName);
        }

        public async Task<List<GestaoVeiculos>> GetVeiculosAsync() =>
            await _gestaoVeiculosCollection.Find(x => true).ToListAsync();

        public async Task<GestaoVeiculos> CreateVeiculoAsync(GestaoVeiculos veiculo)
        {
            await _gestaoVeiculosCollection.InsertOneAsync(veiculo);
            return veiculo;
        }

        public async Task<GestaoVeiculos> UpdateVeiculoAsync(GestaoVeiculos veiculo)
        {
            await _gestaoVeiculosCollection.ReplaceOneAsync(x => x.Id == veiculo.Id, veiculo);
            return veiculo;
        }

        public async Task DeleteVeiculoAsync(string veiculoId)
        {
            await _gestaoVeiculosCollection.DeleteOneAsync(x => x.Id == veiculoId);
        }
    }
}
