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
    public class GestaoVeiculosController : ControllerBase
    {
        private readonly IGestaoVeiculosService _gestaoVeiculosService;

        public GestaoVeiculosController(IGestaoVeiculosService gestaoVeiculosService)
        {
            _gestaoVeiculosService = gestaoVeiculosService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var veiculos = await _gestaoVeiculosService.ObterTodos();
                var veiculosDTOs = veiculos.Select(v => MapearParaDTO(v)).ToList();
                return Ok(veiculosDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar veículos",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] GestaoVeiculosDTO veiculoDto)
        {
            try
            {
                var veiculo = MapearParaEntidade(veiculoDto);
                var novoVeiculo = await _gestaoVeiculosService.Adicionar(veiculo);
                var novoVeiculoDTO = MapearParaDTO(novoVeiculo);
                return Ok(novoVeiculoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar veículo",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] GestaoVeiculosDTO veiculoDto)
        {
            try
            {
                var veiculo = MapearParaEntidade(veiculoDto);
                var veiculoAtualizado = await _gestaoVeiculosService.Atualizar(veiculo);
                var veiculoAtualizadoDTO = MapearParaDTO(veiculoAtualizado);
                return Ok(veiculoAtualizadoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar veículo",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{veiculoId}")]
        public IActionResult Delete(string veiculoId)
        {
            try
            {
                _gestaoVeiculosService.Remover(veiculoId);
                return Ok($"Veículo {veiculoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover veículo",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private GestaoVeiculos MapearParaEntidade(GestaoVeiculosDTO dto)
        {
            return new GestaoVeiculos
            {
                Id = dto.Id,
                Modelo = dto.Modelo,
                AnoFabricacao = dto.AnoFabricacao,
                Placa = dto.Placa,
                Status = (StatusVeiculo)dto.Status,
                DataUltimaManutencao = dto.DataUltimaManutencao,
                Kilometragem = dto.Kilometragem
            };
        }

        private GestaoVeiculosDTO MapearParaDTO(GestaoVeiculos veiculo)
        {
            return new GestaoVeiculosDTO
            {
                Id = veiculo.Id,
                Modelo = veiculo.Modelo,
                AnoFabricacao = veiculo.AnoFabricacao,
                Placa = veiculo.Placa,
                Status = (StatusVeiculoDTO)veiculo.Status,
                DataUltimaManutencao = veiculo.DataUltimaManutencao,
                Kilometragem = veiculo.Kilometragem
            };
        }
    }
}
