namespace Dominio;

public class Paciente: Persona
{
    public Guid IdPaciente {get; set;}
    public int NroDNI {get; set;}
    public int NroAfiliado {get; set;}
    public DateTime FechaIngreso {get; set;}
   


    public Paciente( string nombre, string apellido , DateOnly nacimiento,Guid idPaciente,int nroDNI,  int nroAfiliado, DateTime fechaIngreso): base(nombre, apellido, nacimiento)
    {
        IdPaciente= idPaciente;
        NroDNI = nroDNI;
        NroAfiliado = nroAfiliado;
        FechaIngreso = fechaIngreso;
    }

}

