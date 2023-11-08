using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoFinancas.Application.DTOs;
using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentoController(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orcamentos = await _orcamentoService.ObterTodos();
                var orcamentoDTOs = orcamentos.Select(o => MapearParaDTO(o)).ToList();
                return Ok(orcamentoDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar orçamentos",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] OrcamentoDTO orcamentoDto)
        {
            try
            {
                var orcamento = MapearParaEntidade(orcamentoDto);
                var novoOrcamento = await _orcamentoService.Adicionar(orcamento);
                var novoOrcamentoDTO = MapearParaDTO(novoOrcamento);
                return Ok(novoOrcamentoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar orçamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] OrcamentoDTO orcamentoDto)
        {
            try
            {
                var orcamento = MapearParaEntidade(orcamentoDto);
                var orcamentoAtualizado = await _orcamentoService.Atualizar(orcamento);
                var orcamentoAtualizadoDTO = MapearParaDTO(orcamentoAtualizado);
                return Ok(orcamentoAtualizadoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar orçamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{orcamentoId}")]
        public IActionResult Delete(string orcamentoId)
        {
            try
            {
                _orcamentoService.Remover(orcamentoId);
                return Ok($"Orçamento {orcamentoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover orçamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private Orcamento MapearParaEntidade(OrcamentoDTO dto)
        {
            return new Orcamento
            {
                Id = dto.Id,
                DataCriacao = dto.DataCriacao,
                ItensOrcamento = dto.ItensOrcamento.Select(item => new ItemOrcamento
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario
                }).ToList(),
                Status = (StatusOrcamento)dto.Status,
                ClienteId = dto.ClienteId,
                VendedorId = dto.VendedorId,
                Observacoes = dto.Observacoes
            };
        }

        private OrcamentoDTO MapearParaDTO(Orcamento orcamento)
        {
            return new OrcamentoDTO
            {
                Id = orcamento.Id,
                DataCriacao = orcamento.DataCriacao,
                ItensOrcamento = orcamento.ItensOrcamento.Select(item => new ItemOrcamentoDTO
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                    TotalItem = item.TotalItem
                }).ToList(),
                Total = orcamento.Total,
                Status = (StatusOrcamentoDTO)orcamento.Status,
                ClienteId = orcamento.ClienteId,
                VendedorId = orcamento.VendedorId,
                Observacoes = orcamento.Observacoes
            };
        }
    }
}
