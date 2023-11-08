using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Application.Interfaces
{
    public interface IPagamentoService
    {
        Task<List<Pagamento>> ObterTodos();
        Task<Pagamento> Adicionar(Pagamento pagamento);
        Task<Pagamento> Atualizar(Pagamento pagamento);
        void Remover(string pagamentoId);
    }
}
