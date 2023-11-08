using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Infra.Interfaces
{
    public interface IClienteRepository
    {
        public Task<List<Cliente>> GetClienteAsync();
        public Task<Cliente> CreateClienteAsync(Cliente cliente);
        public Task<Cliente> UpdateClienteAsync(Cliente cliente);

        public Task DeleteClienteAsync(string clienteId);
    }
}
