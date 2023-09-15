using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;

[Table("FichaPaciente")]
public class FichaPaciente
{
    [Key]
    [Required]
    public Guid IdFichaPaciente {get; set;}
    [Key]
    [Required]
    public int NroDNI {get; set;}
    [Required]
    [StringLength(50)]
    public string Vacunas {get; set;}
    [Required]
    [StringLength(50)]
    public string Enfermedades {get; set;}
    [Required]
    [StringLength(50)]
    public string Alergias {get; set;}
    [Required]
    [StringLength(50)]
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
