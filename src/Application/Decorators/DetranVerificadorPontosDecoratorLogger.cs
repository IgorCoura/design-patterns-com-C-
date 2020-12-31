using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Implementations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Decorators
{
    class DetranVerificadorPontosDecoratorLogger : IDetranVerificadorPontosService
    {
        private IDetranVerificadorPontosService _Inner;
        private ILogger _Logger;

        public DetranVerificadorPontosDecoratorLogger(IDetranVerificadorPontosService inner, ILogger<DetranVerificadorPontosDecoratorLogger> logger)
        {
            _Inner = inner;
            _Logger = logger;
        }

        public Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh)
        {
            var cnh;
            Stopwatch watch = Stopwatch.StartNew();
            _Logger.LogInformation($"Iniciando a execução do método ConsultarDebitos({cnh})");
            var result = await _Inner.ConsultarDebitos(cnh);
            watch.Stop();
            _Logger.LogInformation($"Encerrando a execução do método ConsultarDebitos({cnh}) {watch.ElapsedMilliseconds}ms");
            return result;
        }
    }
}
