using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;

[Table("Atencion")]
public class Atencion
{
    [Key]
    [Required]
    public Guid IdAtencion {get; set;}
    
    [Required]
    public Guid IdPaciente {get; set;}
    [Required]
    [StringLength(50)]
    public string Matricula {get; set;}
    [Required]
    [StringLength(50)]
    public string Descripcion {get; set;}
    [Required]
    public DateTime FechaHora {get;set;}
    [Required]
    public int NroHabitacion {get; set;}
    public Atencion(Guid idAtencion, Guid idPaciente, string matricula, string descripcion, DateTime fechaHora, int nroHabitacion)
    {
        IdAtencion = idAtencion;
        IdPaciente = idPaciente;
        Matricula = matricula;
        Descripcion = descripcion;
        FechaHora = fechaHora;
        NroHabitacion = nroHabitacion;
    }

    public void ModificarAtencion (string matricula, string descripcion, int nroHabitacion){
        this.Matricula= matricula; 
        this.Descripcion= descripcion;
        this.NroHabitacion= nroHabitacion;
    }
}
