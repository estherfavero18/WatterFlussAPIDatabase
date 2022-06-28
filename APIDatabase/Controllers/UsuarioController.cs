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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var response = _usuarioService.GetAll();
                if (response.Count == 0)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar usuários: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _usuarioService.GetById(id);
                if (response == null)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar o usuário: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca um usuário pelo login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpGet("GetByLogin")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetByLogin([Required] string email, [Required] string senha)
        {
            try
            {
                var response = _usuarioService.GetByLogin(email, senha);
                if (response == null)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar o usuário: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca usuário pelo email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("GetByEmail")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetByEmail([Required] string email)
        {
            try
            {
                var response = _usuarioService.GetByEmail(email);
                if (response == null)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar o usuário: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Busca usuário pelo cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("GetByCpf")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetByCpf([Required] string cpf)
        {
            try
            {
                var response = _usuarioService.GetByCpf(cpf);
                if (response == null)
                    return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string message = "Erro ao buscar o usuário: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] UsuarioModel usuario)
        {
            try
            {
                return Ok(_usuarioService.Post(usuario));
            }
            catch (Exception ex)
            {
                string message = "Erro ao criar o usuário: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Edita um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Put([FromBody] UsuarioModel usuario)
        {
            try
            {
                return Ok(_usuarioService.Put(usuario));
            }
            catch (Exception ex)
            {
                string message = "Erro ao editar o usuário: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
        /// <summary>
        /// Exclui um usuário
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
                _usuarioService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                string message = "Erro ao excluir o usuário: " + ex.Message;
                return new BadRequestObjectResult(message);
            }
        }
    }
}
