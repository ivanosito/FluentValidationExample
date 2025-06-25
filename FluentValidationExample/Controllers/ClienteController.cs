using FluentValidationExample.Interfaces;
using FluentValidationExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FluentValidationExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        //// Simulación de base de datos en memoria
        //private static readonly List<Cliente> Clientes = new()
        //{
        //    new Cliente { Nombre = "María", Edad = 28 },
        //    new Cliente { Nombre = "Carlos", Edad = 35 }
        //};

        private readonly IClienteRepository _repo;
        public ClienteController(IClienteRepository repo) => _repo = repo;

        // GET /api/cliente
        [HttpGet]
        public IActionResult GetClientes() => Ok(_repo.GetAll());


        // GET /api/cliente/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetClienteById(int id)
            => _repo.GetByIndex(id) is { } c ? Ok(c) : NotFound();

        // POST /api/cliente
        [HttpPost]
        public IActionResult PostCliente([FromBody] Cliente cliente)
        {
            _repo.Add(cliente);
            return Ok(new { message = "Cliente agregado.", datos = cliente });
        }


        // PUT /api/cliente/{id}
        [HttpPut("{id:int}")]
        public IActionResult PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (_repo.GetByIndex(id) is null) return NotFound();
            _repo.Update(id, cliente);
            return Ok(new { message = "Cliente actualizado.", datos = cliente });
        }

        // DELETE /api/cliente/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCliente(int id)
        => _repo.Delete(id, out var eliminado)
              ? Ok(new { message = "Cliente eliminado.", datos = eliminado })
              : NotFound();
    }
}
