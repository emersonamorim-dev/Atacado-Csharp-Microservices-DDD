using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IGestaoRotasService
    {
        Task<List<GestaoRotas>> ObterTodasRotas();
        Task<GestaoRotas> AdicionarRota(GestaoRotas rota);
        Task<GestaoRotas> AtualizarRota(GestaoRotas rota);
        Task RemoverRota(string rotaId);
    }
}
