namespace Aplicacion.ViewModels;

public class AtencionVM
{
    public Guid IdAtencion {get; set;}
    public Guid IdPaciente {get; set;}
    public string Matricula {get; set;}
    public string Descripcion {get; set;}
    public DateTime FechaHora {get; set;} 
    public int NroHabitacion {get;set;}
    
}
