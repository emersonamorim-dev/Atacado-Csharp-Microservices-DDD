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
    public class RiscosController : ControllerBase
    {
        private readonly IRiscosService _riscosService;

        public RiscosController(IRiscosService riscosService)
        {
            _riscosService = riscosService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var riscos = await _riscosService.ObterTodos();
                var riscosDTOs = riscos.Select(r => MapearParaDTO(r)).ToList();
                return Ok(riscosDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar riscos",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] RiscosDTO riscosDto)
        {
            try
            {
                var riscos = MapearParaEntidade(riscosDto);
                var novoRisco = await _riscosService.Adicionar(riscos);
                var novoRiscoDTO = MapearParaDTO(novoRisco);
                return Ok(novoRiscoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar risco",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] RiscosDTO riscosDto)
        {
            try
            {
                var riscos = MapearParaEntidade(riscosDto);
                var riscoAtualizado = await _riscosService.Atualizar(riscos);
                var riscoAtualizadoDTO = MapearParaDTO(riscoAtualizado);
                return Ok(riscoAtualizadoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar risco",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{riscosId}")]
        public IActionResult Delete(string riscosId)
        {
            try
            {
                _riscosService.Remover(riscosId);
                return Ok($"Risco {riscosId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover risco",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private Riscos MapearParaEntidade(RiscosDTO dto)
        {
            return new Riscos
            {
                Id = dto.Id,
                Descricao = dto.Descricao,
                DataIdentificacao = dto.DataIdentificacao,
                NivelRisco = (NivelRisco)dto.NivelRisco,
                EstrategiaMitigacao = dto.EstrategiaMitigacao,
                Status = (StatusRisco)dto.Status,
                Observacoes = dto.Observacoes
            };
        }

        private RiscosDTO MapearParaDTO(Riscos riscos)
        {
            return new RiscosDTO
            {
                Id = riscos.Id,
                Descricao = riscos.Descricao,
                DataIdentificacao = riscos.DataIdentificacao,
                NivelRisco = (NivelRiscoDTO)riscos.NivelRisco,
                EstrategiaMitigacao = riscos.EstrategiaMitigacao,
                Status = (StatusRiscoDTO)riscos.Status,
                Observacoes = riscos.Observacoes
            };
        }
    }
}
