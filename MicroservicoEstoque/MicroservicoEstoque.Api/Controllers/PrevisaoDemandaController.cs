using System;
using System.Threading.Tasks;
using MicroservicoEstoque.Application.DTOs;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicoEstoque.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrevisaoDemandaController : ControllerBase
    {
        private readonly IPrevisaoDemandaService _previsaoDemandaService;

        public PrevisaoDemandaController(IPrevisaoDemandaService previsaoDemandaService)
        {
            _previsaoDemandaService = previsaoDemandaService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var previsoesDemanda = await _previsaoDemandaService.ObterTodos();
                return Ok(previsoesDemanda);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar previsões de demanda",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PrevisaoDemandaDTO previsaoDemandaDto)
        {
            try
            {
                PrevisaoDemanda MapearParaEntidade(PrevisaoDemandaDTO dto)
                {
                    return new PrevisaoDemanda
                    {
                        Id = dto.Id,
                        ProdutoId = dto.ProdutoId,
                        NomeProduto = dto.NomeProduto,
                        Previsao = dto.Previsao,
                        DataPrevisao = dto.DataPrevisao,
                        HistoricoVendas = dto.HistoricoVendas.ConvertAll(item => new VendaHistorica
                        {
                            DataVenda = item.DataVenda,
                            QuantidadeVendida = item.QuantidadeVendida
                        })
                    };
                }

                var previsaoDemanda = MapearParaEntidade(previsaoDemandaDto);
                var novaPrevisaoDemanda = await _previsaoDemandaService.Adicionar(previsaoDemanda);
                return Ok(novaPrevisaoDemanda);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar previsão de demanda",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] PrevisaoDemandaDTO previsaoDemandaDto)
        {
            try
            {
                PrevisaoDemanda MapearParaEntidade(PrevisaoDemandaDTO dto)
                {
                    return new PrevisaoDemanda
                    {
                        Id = dto.Id,
                        ProdutoId = dto.ProdutoId,
                        NomeProduto = dto.NomeProduto,
                        Previsao = dto.Previsao,
                        DataPrevisao = dto.DataPrevisao,
                        HistoricoVendas = dto.HistoricoVendas.ConvertAll(item => new VendaHistorica
                        {
                            DataVenda = item.DataVenda,
                            QuantidadeVendida = item.QuantidadeVendida
                        })
                    };
                }

                var previsaoDemanda = MapearParaEntidade(previsaoDemandaDto);
                var previsaoDemandaAtualizada = await _previsaoDemandaService.Atualizar(previsaoDemanda);
                return Ok(previsaoDemandaAtualizada);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar previsão de demanda",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{previsaoDemandaId}")]
        public IActionResult Delete(string previsaoDemandaId)
        {
            try
            {
                _previsaoDemandaService.Remover(previsaoDemandaId);
                return Ok($"Previsão de demanda {previsaoDemandaId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover previsão de demanda",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
