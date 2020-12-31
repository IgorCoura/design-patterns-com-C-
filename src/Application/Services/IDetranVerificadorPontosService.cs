using DesignPatternSamples.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Implementations
{
    public interface IDetranVerificadorPontosService
    {
        Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh);
    }
}