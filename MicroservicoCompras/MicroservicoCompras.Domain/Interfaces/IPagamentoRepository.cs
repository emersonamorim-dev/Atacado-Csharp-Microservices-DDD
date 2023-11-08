using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Infra.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<List<Pagamento>> GetPagamentoAsync();
        Task<Pagamento> CreatePagamentoAsync(Pagamento pagamento);
        Task<Pagamento> UpdatePagamentoAsync(Pagamento pagamento);
        Task DeletePagamentoAsync(string pagamentoId);
    }
}
