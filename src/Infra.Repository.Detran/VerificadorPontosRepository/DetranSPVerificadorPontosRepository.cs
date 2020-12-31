using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranSPVerificadorPontosRepository: IDetranVerificadorPontosRepository
    {
        private readonly ILogger<IDetranVerificadorDebitosRepository> _Logger;

        public DetranSPVerificadorPontosRepository(ILogger<IDetranVerificadorDebitosRepository> logger)
        {
           _Logger = logger;
        }

        public Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh)
        {
            Task.Delay(5000).Wait(); //Deixando o serviço mais lento para evidenciar o uso do CACHE.
            _Logger.LogDebug($"Consultado Pontos para a CHN de registro: {cnh.Registro} para o estado SP");
            return Task.FromResult<IEnumerable<PontosCNH>>(new List<PontosCNH>() { new PontosCNH() });
        }
    }
}
