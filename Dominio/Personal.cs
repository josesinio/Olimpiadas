using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Personal")]
public class Personal
{
    [Key]
    [Required]
    public Guid IdPersonal {get; set;}
    [Required]
    [StringLength(50)]
    public string Nombre {get; set;}
    [Required]
    [StringLength(50)]
    public string Apellido {get; set;}
    [Required]
    [StringLength(50)]
    public string Area {get; set;}


    public Personal(Guid idPersonal, string nombre, string apellido, string area)
    {
        IdPersonal = idPersonal;
        Nombre = nombre;
        Apellido= apellido;
        Area = area;        
    }

}
