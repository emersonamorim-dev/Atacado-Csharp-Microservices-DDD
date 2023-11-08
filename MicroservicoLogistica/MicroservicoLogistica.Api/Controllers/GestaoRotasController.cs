using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoLogistica.Application.DTOs;
using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;

namespace MicroservicoLogistica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GestaoRotasController : ControllerBase
    {
        private readonly IGestaoRotasService _gestaoRotasService;

        public GestaoRotasController(IGestaoRotasService gestaoRotasService)
        {
            _gestaoRotasService = gestaoRotasService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rotas = await _gestaoRotasService.ObterTodasRotas(); // Corrigido
                var rotasDTOs = rotas.Select(r => MapearParaDTO(r)).ToList();
                return Ok(rotasDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar rotas",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] GestaoRotasDTO rotaDto)
        {
            try
            {
                var rota = MapearParaEntidade(rotaDto);
                var novaRota = await _gestaoRotasService.AdicionarRota(rota); // Corrigido
                var novaRotaDTO = MapearParaDTO(novaRota);
                return Ok(novaRotaDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar rota",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] GestaoRotasDTO rotaDto)
        {
            try
            {
                var rota = MapearParaEntidade(rotaDto);
                var rotaAtualizada = await _gestaoRotasService.AtualizarRota(rota); // Corrigido
                var rotaAtualizadaDTO = MapearParaDTO(rotaAtualizada);
                return Ok(rotaAtualizadaDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar rota",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{rotaId}")]
        public async Task<IActionResult> Delete(string rotaId) // Adicionado async Task<IActionResult>
        {
            try
            {
                await _gestaoRotasService.RemoverRota(rotaId); // Corrigido
                return Ok($"Rota {rotaId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover rota",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private GestaoRotas MapearParaEntidade(GestaoRotasDTO dto)
        {
            return new GestaoRotas
            {
                Id = dto.Id,
                Origem = dto.Origem,
                Destino = dto.Destino,
                VeiculoId = dto.VeiculoId,
                DataHoraPartida = dto.DataHoraPartida,
                DataHoraChegadaPrevista = dto.DataHoraChegadaPrevista,
                Status = (StatusRota)dto.Status,
                KilometragemPrevista = dto.KilometragemPrevista,
                KilometragemPercorrida = dto.KilometragemPercorrida,
                Observacoes = dto.Observacoes
            };
        }

        private GestaoRotasDTO MapearParaDTO(GestaoRotas rota)
        {
            return new GestaoRotasDTO
            {
                Id = rota.Id,
                Origem = rota.Origem,
                Destino = rota.Destino,
                VeiculoId = rota.VeiculoId,
                DataHoraPartida = rota.DataHoraPartida,
                DataHoraChegadaPrevista = rota.DataHoraChegadaPrevista,
                Status = (StatusRotaDTO)rota.Status,
                KilometragemPrevista = rota.KilometragemPrevista,
                KilometragemPercorrida = rota.KilometragemPercorrida,
                Observacoes = rota.Observacoes
            };
        }
    }
}
