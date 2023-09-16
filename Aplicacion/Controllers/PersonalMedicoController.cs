using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonalMedicoController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public PersonalMedicoController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var medicos = contexto.PersonalesMedicos;
        return Ok(medicos);
    }

    [HttpGet("{id:Guid}")]
    public ActionResult Get(Guid id)
    {
        var medico = contexto.PersonalesMedicos.FirstOrDefault(x => x.IdPersonalMedico == id);
        return Ok(medico);
    }

    [HttpPost]
    public ActionResult Post([FromBody] PersonalMedicoVM personalMedico)
    {
        var  nuevomedico = new PersonalMedico(idPersonalMedico: new Guid(),personalMedico.Matricula, personalMedico.Area, personalMedico.Nombre, personalMedico.Apellido );
        contexto.Add(nuevomedico);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:Guid}")]
    public ActionResult Put([FromBody] PersonalMedicoVM personalMedico, Guid id)
    {
        var personalMedicoModificar = contexto.PersonalesMedicos.FirstOrDefault(x => x.IdPersonalMedico == id);

        if (personalMedicoModificar is null)
            throw new Exception("no existe un personal medico con ese Id.");

        personalMedicoModificar.ModificarPersonal(personalMedico.Matricula);
        contexto.SaveChanges();
        return Ok(personalMedicoModificar);
    }
    [HttpDelete("{id:Guid}")]
    public ActionResult Delete(Guid id)
    {
        var personalMedicoBorrar = contexto.PersonalesMedicos.FirstOrDefault(x => x.IdPersonalMedico == id);

        if (personalMedicoBorrar is null)
            throw new Exception("no existe algun personal medico con ese Id.");

        contexto.PersonalesMedicos.Remove(personalMedicoBorrar);
        contexto.SaveChanges();
        return Ok();
    }
}
