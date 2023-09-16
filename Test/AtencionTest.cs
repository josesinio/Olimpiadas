using System.Runtime.CompilerServices;
using Dominio;
using Xunit;
namespace Test;

public class AtencionTest
{
    public Atencion atencionprueba {get; set;}
    public AtencionTest()
    {
        atencionprueba = new Atencion(new Guid(), new Guid(), "g1g1", "es cornudo", DateTime.Now, 12);
    }

    [Fact]
    public void modificar()
    {
        var matricula1 = "l1l1l1";
        var descripcion1 = "cornudo naciste";
        var nuevaHabitacion = 12;
        atencionprueba.ModificarAtencion(matricula1, descripcion1, nuevaHabitacion);
        Assert.Equal(matricula1, atencionprueba.Matricula);
        Assert.Equal(descripcion1, atencionprueba.Descripcion);
        Assert.Equal(nuevaHabitacion, atencionprueba.NroHabitacion);
    }
}