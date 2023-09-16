using System.Diagnostics.CodeAnalysis;
using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FichaPacienteController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public FichaPacienteController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var Fichas = contexto.FichasPacientes;
        return Ok(Fichas);
    }

    [HttpGet("{id:Guid}")]
    public ActionResult Get(Guid id)
    {
        var atencion = contexto.FichasPacientes.FirstOrDefault(x => x.IdFichaPaciente == id);
        return Ok(atencion);
    }

        [HttpPost]
    public ActionResult Post([FromBody] FichaPacienteVM ficha)
    {
        var  nuevoFicha = new FichaPaciente(idFichaPaciente: new Guid(), ficha.NroDNI, ficha.Vacunas, ficha.Enfermedades, ficha.Alergias, ficha.TipoSangre);
        contexto.Add(nuevoFicha);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:Guid}")]
    public ActionResult Put([FromBody] FichaPacienteVM ficha, Guid id)
    {
        var fichaModificar = contexto.FichasPacientes.FirstOrDefault(x => x.IdFichaPaciente == id);

        if (fichaModificar is null)
            throw new Exception("no existe un administrador  con ese Id.");

        fichaModificar.ModificarFicha(ficha.Vacunas, ficha.Enfermedades, ficha.Alergias);
        contexto.SaveChanges();
        return Ok(fichaModificar);
    }
    


}
