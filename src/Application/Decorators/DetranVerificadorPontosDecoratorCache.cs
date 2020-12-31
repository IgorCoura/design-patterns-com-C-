using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Implementations;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Workbench.IDistributedCache.Extensions;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorPontosDecoratorCache: IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosService _Inner;
        private readonly IDistributedCache _Cache;

        public DetranVerificadorPontosDecoratorCache(IDetranVerificadorPontosService inner, IDistributedCache cache)
        {
            _Inner = inner;
            _Cache = cache;
        }

        public Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh)
        {
            return Task.FromResult(_Cache.GetOrCreate($"{cnh.UF}_{cnh.CPF}_{cnh.Registro}", () => _Inner.ConsultarPontos(cnh).Result));
        }
    }
}
