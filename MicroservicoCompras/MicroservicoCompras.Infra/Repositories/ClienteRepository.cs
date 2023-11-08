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
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clienteCollection;

        public ClienteRepository(IOptions<ClientesDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _clienteCollection = mongoDatabase.GetCollection<Cliente>(settings.Value.CollectionName);
        }

        public async Task<List<Cliente>> GetClienteAsync() =>
            await _clienteCollection.Find(x => true).ToListAsync();

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            await _clienteCollection.InsertOneAsync(cliente);

            return cliente;
        }
        public async Task DeleteClienteAsync(string clienteId)
        {
            await _clienteCollection.DeleteOneAsync(x => x.Id == clienteId);
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            await _clienteCollection.ReplaceOneAsync(x => x.Id == cliente.Id, cliente);
            return cliente;
        }

    }
}
