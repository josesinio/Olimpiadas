using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Usuario")]
public class Usuario
{
    [Key]
    [Required]
    public Guid IdUsuario {get; set;}
    [Key]
    [Required]
    public Guid IdPersonal {get; set;}
    [Required]
    [StringLength(50)]
    public string Matricula {get; set;}
    [Required]
    [StringLength(50)]
    public string Email {get; set;}
    [Required]
    [StringLength(50)]
    public string Contrasenia {get;set;}
    [Required]
    [StringLength(50)]
    public string TipoUsuario {get;set;}


    public Usuario(Guid idUsuario, Guid idPersonal,string matricula, string email, string contrasenia,string tipoUsuario)
    {
        IdUsuario = idUsuario;
        IdPersonal = idPersonal;
        Matricula  = matricula;
        Email = email;
        Contrasenia = contrasenia;
        TipoUsuario = tipoUsuario;
    }


}
