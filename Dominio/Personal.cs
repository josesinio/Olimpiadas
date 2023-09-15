namespace Dominio;

public class Personal
{
    public Guid IdPersonal {get; set;}
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public string Area {get; set;}


    public Personal(Guid idPersonal, string nombre, string apellido, string area)
    {
        IdPersonal = idPersonal;
        Nombre = nombre;
        Apellido= apellido;
        Area = area;        
    }

}
