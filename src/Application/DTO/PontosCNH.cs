using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSamples.Application.DTO
{
    [Serializable]
    public class PontosCNH
    {
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public double Pontos { get; set; }
    }
}
