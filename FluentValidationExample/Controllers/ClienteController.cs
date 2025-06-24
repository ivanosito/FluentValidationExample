using FluentValidationExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FluentValidationExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        // Simulación de base de datos en memoria
        private static readonly List<Cliente> Clientes = new()
        {
            new Cliente { Nombre = "María", Edad = 28 },
            new Cliente { Nombre = "Carlos", Edad = 35 }
        };

        // GET /api/cliente
        [HttpGet]
        public IActionResult GetClientes() => Ok(Clientes);

        // GET /api/cliente/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetClienteById(int id)
        {
            if (id < 0 || id >= Clientes.Count)
                return NotFound(new { message = "Cliente no encontrado." });

            return Ok(Clientes[id]);
        }

        // POST /api/cliente
        [HttpPost]
        public IActionResult PostCliente([FromBody] Cliente cliente)
        {
            Clientes.Add(cliente);
            return Ok(new { message = "Cliente agregado correctamente.", datos = cliente });
        }

        // PUT /api/cliente/{id}
        [HttpPut("{id:int}")]
        public IActionResult PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (id < 0 || id >= Clientes.Count)
                return NotFound(new { message = "Cliente no encontrado." });

            Clientes[id] = cliente;
            return Ok(new { message = "Cliente actualizado correctamente.", datos = cliente });
        }

        // DELETE /api/cliente/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCliente(int id)
        {
            if (id < 0 || id >= Clientes.Count)
                return NotFound(new { message = "Cliente no encontrado." });

            var eliminado = Clientes[id];
            Clientes.RemoveAt(id);
            return Ok(new { message = "Cliente eliminado correctamente.", datos = eliminado });
        }
    }
}
