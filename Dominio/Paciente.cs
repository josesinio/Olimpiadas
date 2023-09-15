using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Paciente")]
public class Paciente: Persona
{
    [Key]
    [Required]
    public Guid IdPaciente {get; set;}
    [Key]
    [Required]
    public int NroDNI {get; set;}
    [Required]
    public int NroAfiliado {get; set;}
    [Required]
    public DateTime FechaIngreso {get; set;}
   


    public Paciente( string nombre, string apellido , DateOnly nacimiento,Guid idPaciente,int nroDNI,  int nroAfiliado, DateTime fechaIngreso): base(nombre, apellido, nacimiento)
    {
        IdPaciente= idPaciente;
        NroDNI = nroDNI;
        NroAfiliado = nroAfiliado;
        FechaIngreso = fechaIngreso;
    }

}

