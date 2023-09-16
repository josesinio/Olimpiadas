using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("PersonalMedico")]
public class PersonalMedico
{
    [Key]
    [Required]
    public Guid IdPersonalMedico {get; set;}
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


    public PersonalMedico(Guid idPersonalMedico, string matricula,string area, string nombre, string apellido )
    {
        IdPersonalMedico = idPersonalMedico;  
        Matricula = matricula;
        Area = area ;
        Nombre = nombre;
        Apellido = apellido;
    }

    public void ModificarPersonal(string matricula)
    {
        this.Matricula = matricula;
    }

}
