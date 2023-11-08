using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoMarketing.Domain.Entities;
using MicroservicoMarketing.Domain.Interfaces;
using MicroservicoMarketing.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroservicoMarketing.Infra.Repositories
{
    public class SegmentacaoClientesRepository : ISegmentacaoClientesRepository
    {
        private readonly IMongoCollection<SegmentacaoClientes> _segmentacaoClientesCollection;

        public SegmentacaoClientesRepository(IOptions<SegmentacaoClientesDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _segmentacaoClientesCollection = mongoDatabase.GetCollection<SegmentacaoClientes>(settings.Value.CollectionName);
        }

        public async Task<List<SegmentacaoClientes>> GetSegmentacoesAsync() =>
            await _segmentacaoClientesCollection.Find(x => true).ToListAsync();

        public async Task<SegmentacaoClientes> CreateSegmentacaoAsync(SegmentacaoClientes segmentacao)
        {
            await _segmentacaoClientesCollection.InsertOneAsync(segmentacao);
            return segmentacao;
        }

        public async Task<SegmentacaoClientes> UpdateSegmentacaoAsync(SegmentacaoClientes segmentacao)
        {
            await _segmentacaoClientesCollection.ReplaceOneAsync(x => x.Id == segmentacao.Id, segmentacao);
            return segmentacao;
        }

        public async Task DeleteSegmentacaoAsync(string segmentacaoId)
        {
            await _segmentacaoClientesCollection.DeleteOneAsync(x => x.Id == segmentacaoId);
        }
    }
}
