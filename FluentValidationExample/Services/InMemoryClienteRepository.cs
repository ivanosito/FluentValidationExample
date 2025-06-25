using FluentValidationExample.Interfaces;
using FluentValidationExample.Models;
using System.Collections.Generic;

namespace FluentValidationExample.Services
{
    public class InMemoryClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes = new()
        {
            new() { Nombre = "María",  Edad = 28 },
            new() { Nombre = "Carlos", Edad = 35 }
        };

        public IReadOnlyList<Cliente> GetAll() => _clientes;
        public Cliente? GetByIndex(int index) => index >= 0 && index < _clientes.Count ? _clientes[index] : null;
        public void Add(Cliente cliente) => _clientes.Add(cliente);
        public void Update(int index, Cliente cliente) => _clientes[index] = cliente;
        public bool Delete(int index, out Cliente? deleted)
        {
            if (index < 0 || index >= _clientes.Count) { deleted = null; return false; }
            deleted = _clientes[index];
            _clientes.RemoveAt(index);
            return true;
        }
    }
}

