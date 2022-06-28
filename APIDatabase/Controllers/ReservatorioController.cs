using APIDatabase.Models;
using APIDatabase.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservatorioController : ControllerBase
    {
        private readonly IReservatorioService _reservatorioService;

        public ReservatorioController(IReservatorioService reservatorioService)
        {
            _reservatorioService = reservatorioService;
        }
        /// <summary>
        /// Retorna todos os reservatórios 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ReservatorioModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var response = _reservatorioService.GetAll();
                if (response.Count == 0)
                    return NoContent();
                return Ok(response);
            }
            catch(Exception ex)
            {
                string message = "Erro ao buscar reservatórios: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca um reservaatório pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReservatorioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _reservatorioService.GetById(id);
                if (response == null)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar o reservatório: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca reservatório pelo email do usuário
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("BuscaPorUsuario")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReservatorioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetByUsuario([Required] string email)
        {
            try
            {
                var response = _reservatorioService.GetByUsuario(email);
                if (response == null)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar o reservatório: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Cria um repositório
        /// </summary>
        /// <param name="repositorio"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReservatorioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] ReservatorioModel repositorio)
        {
            try
            {
                return Ok(_reservatorioService.Post(repositorio));
            }
            catch (Exception ex)
            {
                string message = "Erro ao criar o reservatório: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Edita um repositório
        /// </summary>
        /// <param name="repositorio"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReservatorioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Put([FromBody] ReservatorioModel repositorio)
        {
            try
            {
                return Ok(_reservatorioService.Put(repositorio));
            }
            catch (Exception ex)
            {
                string message = "Erro ao editar o reservatório: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Exclui um reservatório
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                _reservatorioService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                string message = "Erro ao excluir o reservatório: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
    }
}
