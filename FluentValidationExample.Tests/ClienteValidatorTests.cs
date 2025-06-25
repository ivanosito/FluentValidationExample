using FluentValidation.TestHelper;
using FluentValidationExample.Models;
using FluentValidationExample.Validators;
using Xunit;

public class ClienteValidatorTests
{
    private readonly ClienteValidator _validator = new();

    [Theory]
    [InlineData("", 30)]
    [InlineData("", 17)]
    public void Nombre_Invalido_Debe_Fallar(string nombre, int edad)
    {
        var model = new Cliente { Nombre = nombre, Edad = edad };
        _validator.TestValidate(model)
                  .ShouldHaveValidationErrorFor(c => c.Nombre);
    }

    [Theory]
    [InlineData("Luis", 15)]
    [InlineData("María", 70)]
    public void Edad_FueraDeRango_Debe_Fallar(string nombre, int edad)
    {
        var model = new Cliente { Nombre = nombre, Edad = edad };
        _validator.TestValidate(model)
                  .ShouldHaveValidationErrorFor(c => c.Edad);
    }

    [Fact]
    public void Datos_Validos_Pasan_Validacion()
    {
        var model = new Cliente { Nombre = "Ana", Edad = 25 };
        _validator.TestValidate(model)
                  .ShouldNotHaveAnyValidationErrors();
    }
}
