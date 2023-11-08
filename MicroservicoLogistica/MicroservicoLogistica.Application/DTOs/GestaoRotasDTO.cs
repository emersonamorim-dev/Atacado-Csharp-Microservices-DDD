using System;

namespace MicroservicoLogistica.Application.DTOs
{
    public class GestaoRotasDTO
    {
        public string Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string VeiculoId { get; set; }
        public DateTime DataHoraPartida { get; set; }
        public DateTime DataHoraChegadaPrevista { get; set; }
        public StatusRotaDTO Status { get; set; }
        public int KilometragemPrevista { get; set; }
        public int KilometragemPercorrida { get; set; }
        public string Observacoes { get; set; }
    }

    public enum StatusRotaDTO
    {
        Planejada,
        EmAndamento,
        Concluida,
        Cancelada
    }
}
