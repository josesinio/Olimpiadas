using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Paciente")]
public class Paciente
{
    [Key]
    [Required]
    public Guid IdPaciente {get; set;}
    
    [Required]
    public int NroDNI {get; set;}
    [Required]
    public int NroAfiliado {get; set;}
    [Required]
    public DateTime FechaIngreso {get; set;}

    public Paciente( Guid idPaciente,int nroDNI,  int nroAfiliado, DateTime fechaIngreso)
    {
        IdPaciente= idPaciente;
        NroDNI = nroDNI;
        NroAfiliado = nroAfiliado;
        FechaIngreso = fechaIngreso;
    }

}

