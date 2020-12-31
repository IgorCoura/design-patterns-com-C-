using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Implementations
{
    public class DetranVerificadorPontosServices : IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosFactory _Factory;

        public DetranVerificadorPontosServices(IDetranVerificadorPontosFactory factory)
        {
            _Factory = factory;
        }

        public Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh)
        {
            IDetranVerificadorPontosRepository repository = _Factory.Create(cnh.UF);
            return repository.ConsultarPontos(cnh);
        }
    }
}
