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
    public class GestaoRotasRepository : IGestaoRotasRepository
    {
        private readonly IMongoCollection<GestaoRotas> _rotasCollection;

        public GestaoRotasRepository(IOptions<GestaoRotasDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _rotasCollection = mongoDatabase.GetCollection<GestaoRotas>(settings.Value.CollectionName);
        }

        public async Task<List<GestaoRotas>> GetRotasAsync() =>
            await _rotasCollection.Find(x => true).ToListAsync();

        public async Task<GestaoRotas> GetRotaByIdAsync(string rotaId) =>
            await _rotasCollection.Find<GestaoRotas>(r => r.Id == rotaId).FirstOrDefaultAsync();

        public async Task<GestaoRotas> CreateRotaAsync(GestaoRotas rota)
        {
            await _rotasCollection.InsertOneAsync(rota);
            return rota;
        }

        public async Task UpdateRotaAsync(GestaoRotas rota) =>
            await _rotasCollection.ReplaceOneAsync(r => r.Id == rota.Id, rota);

        public async Task DeleteRotaAsync(string rotaId) =>
            await _rotasCollection.DeleteOneAsync(r => r.Id == rotaId);
    }
}
