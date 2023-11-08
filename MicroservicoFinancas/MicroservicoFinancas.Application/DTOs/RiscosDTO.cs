using System;
using System.Collections.Generic;

namespace MicroservicoFinancas.Application.DTOs
{
    public class RiscosDTO
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataIdentificacao { get; set; }
        public NivelRiscoDTO NivelRisco { get; set; }
        public string EstrategiaMitigacao { get; set; }
        public StatusRiscoDTO Status { get; set; }
        public string Observacoes { get; set; }
    }

    public enum NivelRiscoDTO
    {
        Baixo,
        Moderado,
        Alto,
        Critico
    }

    public enum StatusRiscoDTO
    {
        Identificado,
        Analisado,
        Mitigado,
        Monitorado,
        Encerrado
    }
}
