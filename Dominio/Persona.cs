namespace Dominio;

public class Persona
{
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public DateOnly Nacimiento {get; set;}
    public Persona(string nombre, string apellido, DateOnly nacimiento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Nacimiento = nacimiento;  
    }

}
