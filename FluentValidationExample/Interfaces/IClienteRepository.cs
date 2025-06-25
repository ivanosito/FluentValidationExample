using FluentValidationExample.Models;
using System.Collections.Generic;

namespace FluentValidationExample.Interfaces
{
    public interface IClienteRepository
    {
        IReadOnlyList<Cliente> GetAll();
        Cliente? GetByIndex(int index);
        void Add(Cliente cliente);
        void Update(int index, Cliente cliente);
        bool Delete(int index, out Cliente? deleted);
    }
}
