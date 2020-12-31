using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Implementations;
using DesignPatternSamples.WebAPI.Mapper;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class PontosCNHController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificadorPontosService _DetranService;

        public PontosCNHController(IMapper mapper, IDetranVerificadorPontosService detranService)
        {
            _DetranService = detranService;
            _Mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<CNH>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery]CNHModel model)
        {
            var pontos = await _DetranService.ConsultarPontos(_Mapper.Map<CNH>(model));
            var result = new SuccessResultModel<IEnumerable<PontosCNHModel>>(_Mapper.Map<IEnumerable<PontosCNHModel>>(pontos));                
            return Ok(result);
        }
    }
}
