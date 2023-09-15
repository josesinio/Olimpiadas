using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;

[Table("Atencion")]
public class Atencion
{
    [Key]
    [Required]
    public Guid IdAtencion {get; set;}
    [Key]
    [Required]
    public Guid IdPaciente {get; set;}
    [Required]
    [StringLength(50)]
    public string Matricula {get; set;}
    [Required]
    [StringLength(50)]
    public string Descripcion {get; set;}
    [Required]
    public DateOnly Fecha {get;set;}
    [Required]
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
