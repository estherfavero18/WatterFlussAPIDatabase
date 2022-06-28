﻿using APIDatabase.Models;
using APIDatabase.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorVazaoController : ControllerBase
    {
        private readonly ISensorVazaoService _sensorVazaoService;

        public SensorVazaoController(ISensorVazaoService sensorVazaoService)
        {
            _sensorVazaoService = sensorVazaoService;
        }
        /// <summary>
        /// Retorna todas as medições
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<SensorVazaoModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var response = _sensorVazaoService.GetAll();
                if (response.Count == 0)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar medições de sensores de vazão: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca uma medição pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SensorVazaoModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _sensorVazaoService.GetById(id);
                if (response == null)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar a medição do sensor de vazão: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca medições pelo repositório
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByRepositorio/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SensorNivelModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetByRepositorio(int id)
        {
            try
            {
                var response = _sensorVazaoService.GetByRepositorio(id);
                if (response.Count == 0)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar a medição do sensor de nível: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Cria uma medição
        /// </summary>
        /// <param name="medicao"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SensorVazaoModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] SensorVazaoModel medicao)
        {
            try
            {
                return Ok(_sensorVazaoService.Post(medicao));
            }
            catch (Exception ex)
            {
                string message = "Erro ao criar a medição do sensor de vazão: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca última medição do sensoor pelo id do reservatório
        /// </summary>
        /// <param name="idReservatorio"></param>
        /// <returns></returns>
        [HttpGet("GetUltimaMedicao")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SensorVazaoModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetUltimaMedicao(int idReservatorio)
        {
            try
            {
                var response = _sensorVazaoService.GetByRepositorioUltimaMedicao(idReservatorio);

                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar a medição do sensor de nível: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
    }
}
