using System;

namespace DesignPatternSamples.WebAPI.Models.Detran
{
    public class CNHModel
    {
        public string CPF { get; set; }
        public string Registro { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UF { get; set; }


    }
}