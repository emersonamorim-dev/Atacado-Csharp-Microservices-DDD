using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Infra.Interfaces
{
    public interface IVendasRepository
    {
        Task<List<Venda>> GetVendaAsync();
        Task<Venda> CreateVendaAsync(Venda venda);
        Task<Venda> UpdateVendaAsync(Venda venda);
        Task DeleteVendaAsync(string vendaId);
    }
}
