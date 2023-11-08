using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;

namespace MicroservicoLogistica.Application.Services
{
    public class GestaoRotasService : IGestaoRotasService
    {
        private readonly IGestaoRotasRepository _gestaoRotasRepository;

        public GestaoRotasService(IGestaoRotasRepository gestaoRotasRepository)
        {
            _gestaoRotasRepository = gestaoRotasRepository;
        }

        public async Task<List<GestaoRotas>> ObterTodasRotas()
        {
            return await _gestaoRotasRepository.GetRotasAsync();
        }

        public async Task<GestaoRotas> AdicionarRota(GestaoRotas rota)
        {
            if (rota == null)
                throw new Exception("Dados inválidos.");

            return await _gestaoRotasRepository.CreateRotaAsync(rota);
        }

        public async Task<GestaoRotas> AtualizarRota(GestaoRotas rota)
        {
            if (rota == null)
                throw new Exception("Dados inválidos.");

            await _gestaoRotasRepository.UpdateRotaAsync(rota);
            return rota; // Corrigido o erro de conversão de tipo
        }

        public async Task RemoverRota(string rotaId)
        {
            if (string.IsNullOrEmpty(rotaId))
                throw new Exception("O Id da rota é inválido");

            await _gestaoRotasRepository.DeleteRotaAsync(rotaId);
        }
    }
}
