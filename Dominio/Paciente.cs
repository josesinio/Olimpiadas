using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Paciente")]
public class Paciente
{
    [Key]
    [Required]
    public Guid IdPaciente { get; set; }

    [Required]
    public int NroAfiliado { get; set; }
    [Required]
    public DateTime FechaIngreso { get; set; }
    [Required]
    public Persona? Persona { get; set; } = null;

    public Paciente(Guid idPaciente, int nroAfiliado, DateTime fechaIngreso)
    {
        IdPaciente = idPaciente;
        NroAfiliado = nroAfiliado;
        FechaIngreso = fechaIngreso;
    }

}

