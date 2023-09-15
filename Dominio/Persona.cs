using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Persona")]
public class Persona
{
    [Key]
    [Required]
    [StringLength(50)]
    public string Nombre {get; set;}
    [Required]
    [StringLength(50)]
    public string Apellido {get; set;}
    [Required]
    public DateOnly Nacimiento {get; set;}
    public Persona(string nombre, string apellido, DateOnly nacimiento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Nacimiento = nacimiento;  
    }

}
