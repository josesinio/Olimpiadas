namespace Dominio;

public class Usuario
{
    public Guid IdUsuario {get; set;}
    public Guid IdPersonal {get; set;}
    public string Matricula {get; set;}
    public string Email {get; set;}
    public string Contrasenia {get;set;}
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
