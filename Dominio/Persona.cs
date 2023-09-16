using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Persona")]
public class Persona
{
    [Key]
    [Required]
    public int NroDNI { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }
    [Required]
    [StringLength(50)]
    public string Apellido { get; set; }
    [Required]
    public DateOnly Nacimiento { get; set; }
    public Persona(string nombre, int nroDNI, string apellido, DateOnly nacimiento)
    {
        Nombre = nombre;
        NroDNI = nroDNI;
        Apellido = apellido;
        Nacimiento = nacimiento;
    }

}
