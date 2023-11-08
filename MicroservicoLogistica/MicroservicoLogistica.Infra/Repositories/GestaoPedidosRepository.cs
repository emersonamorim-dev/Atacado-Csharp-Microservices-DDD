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
    public class GestaoPedidosRepository : IGestaoPedidosRepository
    {
        private readonly IMongoCollection<GestaoPedidos> _gestaoPedidosCollection;

        public GestaoPedidosRepository(IOptions<GestaoPedidosDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _gestaoPedidosCollection = mongoDatabase.GetCollection<GestaoPedidos>(settings.Value.CollectionName);
        }

        public async Task<List<GestaoPedidos>> GetPedidosAsync() =>
            await _gestaoPedidosCollection.Find(x => true).ToListAsync();

        public async Task<GestaoPedidos> CreatePedidoAsync(GestaoPedidos pedido)
        {
            await _gestaoPedidosCollection.InsertOneAsync(pedido);
            return pedido;
        }

        public async Task<GestaoPedidos> UpdatePedidoAsync(GestaoPedidos pedido)
        {
            await _gestaoPedidosCollection.ReplaceOneAsync(x => x.Id == pedido.Id, pedido);
            return pedido;
        }

        public async Task DeletePedidoAsync(string pedidoId)
        {
            await _gestaoPedidosCollection.DeleteOneAsync(x => x.Id == pedidoId);
        }
    }
}
