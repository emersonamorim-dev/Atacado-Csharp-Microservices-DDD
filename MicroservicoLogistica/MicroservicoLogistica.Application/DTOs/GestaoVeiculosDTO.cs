using System;

namespace MicroservicoLogistica.Application.DTOs
{
    public class GestaoVeiculosDTO
    {
        public string Id { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Placa { get; set; }
        public StatusVeiculoDTO Status { get; set; }
        public DateTime DataUltimaManutencao { get; set; }
        public int Kilometragem { get; set; }
    }

    public enum StatusVeiculoDTO
    {
        Disponivel,
        EmUso,
        EmManutencao,
        Inativo
    }
}
