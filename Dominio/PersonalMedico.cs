namespace Dominio;

public class PersonalMedico
{
    public string Matricula {get; set;}
    public string Area {get; set;}
    public string Nombre {get;set; }
    public string Apellido {get; set;}


    public PersonalMedico(string matricula,string area, string nombre, string apellido )
    {
        Matricula = matricula;
        Area = area ;
        Nombre = nombre;
        Apellido = apellido;
       
    }

}
