﻿using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Implementations;
using DesignPatternSamples.Application.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorPontosDecoratorValidarDados : IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosService _DetranService;
        private string message;

        public DetranVerificadorPontosDecoratorValidarDados(IDetranVerificadorPontosService detranService)
        {
            _DetranService = detranService;
        }

        public Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh)
        {
            if(!ValidarDadosCNH.CPF(cnh.CPF, out message) || !ValidarDadosCNH.Registro(cnh.Registro, out message) 
                || !ValidarDadosCNH.DataNascimento(cnh.DataNascimento, out message))
            {                
                throw new Exception(message);
            }
            return _DetranService.ConsultarPontos(cnh);
        }

       
    }
}
