using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IInventarioService
    {
        Task<List<Inventario>> ObterTodos();
        Task<Inventario> Adicionar(Inventario inventario);
        Task<Inventario> Atualizar(Inventario inventario);
        void Remover(string inventarioId);
    }
}
