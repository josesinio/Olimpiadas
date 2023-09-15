using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("PersonalMedico")]
public class PersonalMedico
{
    [Key]
    [Required]
    [StringLength(50)]
    public string Matricula {get; set;}
    [Required]
    [StringLength(50)]
    public string Area {get; set;}
    [Required]
    [StringLength(50)]
    public string Nombre {get;set; }
    [Required]
    [StringLength(50)]
    public string Apellido {get; set;}


    public PersonalMedico(string matricula,string area, string nombre, string apellido )
    {
        Matricula = matricula;
        Area = area ;
        Nombre = nombre;
        Apellido = apellido;
       
    }

}
