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
    public class RastreamentoEntregasRepository : IRastreamentoEntregasRepository
    {
        private readonly IMongoCollection<RastreamentoEntregas> _rastreamentoEntregasCollection;

        public RastreamentoEntregasRepository(IOptions<RastreamentoEntregasDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _rastreamentoEntregasCollection = mongoDatabase.GetCollection<RastreamentoEntregas>(settings.Value.CollectionName);
        }

        public async Task<List<RastreamentoEntregas>> GetRastreamentosAsync() =>
            await _rastreamentoEntregasCollection.Find(x => true).ToListAsync();

        public async Task<RastreamentoEntregas> CreateRastreamentoAsync(RastreamentoEntregas rastreamento)
        {
            await _rastreamentoEntregasCollection.InsertOneAsync(rastreamento);
            return rastreamento;
        }

        public async Task<RastreamentoEntregas> UpdateRastreamentoAsync(RastreamentoEntregas rastreamento)
        {
            await _rastreamentoEntregasCollection.ReplaceOneAsync(x => x.Id == rastreamento.Id, rastreamento);
            return rastreamento;
        }

        public async Task DeleteRastreamentoAsync(string rastreamentoId)
        {
            await _rastreamentoEntregasCollection.DeleteOneAsync(x => x.Id == rastreamentoId);
        }
    }
}
