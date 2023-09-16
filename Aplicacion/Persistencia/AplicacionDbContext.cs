using Dominio;
using Microsoft.EntityFrameworkCore;


namespace Aplicacion.Persistencia;

public class AplicacionDbContext : DbContext
{
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> opciones): base (opciones)
    {
        
    }
    public DbSet<Atencion> Atenciones {get; set; }
    public DbSet<FichaPaciente> FichasPacientes {get; set;}
    public DbSet<Llamada> Llamadas {get; set;}
    public DbSet<Paciente> Pacientes {get; set;} 
    public DbSet<Persona> Personas {get;set;}
    public DbSet<Personal> Personales {get;set;}
    public DbSet<PersonalMedico> PersonalesMedicos {get;set;}
    public DbSet<Usuario> Usuarios {get;set;}
}
