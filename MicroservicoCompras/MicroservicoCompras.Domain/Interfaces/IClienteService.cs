using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Application.Interfaces
{
    public interface IClienteService
    {
        public Task<List<Cliente>> ObterTodos();
        public Task<Cliente> Adicionar(Cliente cliente);
        public Task<Cliente> Atualizar(Cliente cliente);

        public void Remover(string clienteId);
    }
}
