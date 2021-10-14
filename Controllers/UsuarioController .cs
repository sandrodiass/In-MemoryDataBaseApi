using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using In_MemoryDataBaseApi.context;
using In_MemoryDataBaseApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace In_MemoryDataBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly BancoDados _banco;
        public UsuarioController(BancoDados banco) => _banco =banco;

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                
                return Ok(_banco.Usuario.ToList());
            }
            catch ( Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
              var usuarioAtual = _banco.Usuario.Where(c => c.id == id).FirstOrDefault();
                if (usuarioAtual == null)
                    return NotFound();
                else 

                return Ok(usuarioAtual);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuarios Usuario)
        {
            try
            {
                _banco.Usuario.Add(Usuario);
                _banco.SaveChanges();

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuarios Usuario)
        {
            try
            {
                var usuarioAtual = _banco.Usuario.Where(c => c.id == id).FirstOrDefault();
                if (usuarioAtual == null)
                    return NotFound();
                else 
                {
                    usuarioAtual.nome = usuarioAtual.nome;
                    usuarioAtual.nome = usuarioAtual.email;
                    usuarioAtual.nome = usuarioAtual.endereço;
                    _banco.Update(usuarioAtual);
                    _banco.SaveChanges();
                }
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var usuarioAtual = _banco.Usuario.Where(c => c.id == id).FirstOrDefault();
                if (usuarioAtual == null)
                    return NotFound();
                else
                {
                    _banco.Remove(usuarioAtual);
                    _banco.SaveChanges();
                }
                return Ok();
               
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
