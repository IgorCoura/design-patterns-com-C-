using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Rules;
using DesignPatternSamples.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorDebitosDecoratorValidarDados : IDetranVerificadorDebitosService
    {
        private readonly IDetranVerificadorDebitosService _Inner;

        public DetranVerificadorDebitosDecoratorValidarDados(IDetranVerificadorDebitosService inner)
        {
            _Inner = inner;
        }

        public Task<IEnumerable<DebitoVeiculo>> ConsultarDebitos(Veiculo veiculo)
        {
            if(!ValidarDadosVeiculo.PlacaVeiculo(veiculo.Placa, out string message))
            {
                throw new Exception(message);
            }

            return _Inner.ConsultarDebitos(veiculo);
        }
    }
}
