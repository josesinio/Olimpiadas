namespace Dominio;

public class FichaPaciente
{
    public Guid IdFichaPaciente {get; set;}
    public int NroDNI {get; set;}
    public string Vacunas {get; set;}
    public string Enfermedades {get; set;}
    public string Alergias {get; set;}
    public string TipoSangre {get; set;}
    public FichaPaciente (Guid idFichaPaciente, int nroDNI,string vacunas, string enfermedades, string alergias, string tipoSangre )
    {
        IdFichaPaciente = idFichaPaciente;
        NroDNI = nroDNI ;
        Vacunas = vacunas;
        Enfermedades = enfermedades;
        Alergias = alergias;
        TipoSangre = tipoSangre;
       
    }

}
