using FluentValidationExample.Controllers;
using FluentValidationExample.Interfaces;
using FluentValidationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class ClienteControllerTests
{
    private readonly Mock<IClienteRepository> _repoMock = new();
    private readonly ClienteController _controller;

    public ClienteControllerTests()
    {
        _controller = new ClienteController(_repoMock.Object);
    }

    [Fact]
    public void GetClientes_ReturnsOk_WithList()
    {
        _repoMock.Setup(r => r.GetAll()).Returns(new List<Cliente> { new() { Nombre = "X", Edad = 30 } });

        var result = _controller.GetClientes() as OkObjectResult;

        Assert.NotNull(result);
        var lista = Assert.IsAssignableFrom<IEnumerable<Cliente>>(result!.Value);
        Assert.Single(lista);
    }

    [Fact]
    public void DeleteCliente_ReturnsNotFound_WhenIndexInvalid()
    {
        _repoMock.Setup(r => r.Delete(It.IsAny<int>(), out It.Ref<Cliente?>.IsAny))
                 .Returns(false);

        var result = _controller.DeleteCliente(99);

        Assert.IsType<NotFoundResult>(result);
    }
}
