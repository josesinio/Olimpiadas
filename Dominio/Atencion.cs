namespace Dominio;

public class Atencion
{
    public Guid IdAtencion {get; set;}
    public Guid IdPaciente {get; set;}
    public string Matricula {get; set;}
    public string Descripcion {get; set;}
    public DateOnly Fecha {get;set;}
    public int NroHabitacion {get; set;}
    public Atencion(Guid idAtencion, Guid idPaciente, string matricula, string descripcion, DateOnly fecha, int nroHabitacion)
    {
        IdAtencion = idAtencion;
        IdPaciente = idPaciente;
        Matricula = matricula;
        Descripcion = descripcion;
        Fecha = fecha;
        NroHabitacion = nroHabitacion;
    }

}
