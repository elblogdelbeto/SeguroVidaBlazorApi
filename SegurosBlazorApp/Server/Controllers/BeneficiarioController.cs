using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosBlazorApp.Shared.Models;
using SegurosBlazorApp.Server.Data;

namespace SegurosBlazorApp.Server.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BeneficiarioController : ControllerBase
    {
        private readonly APIcontext _context;

        public BeneficiarioController(APIcontext context)
        {
            _context = context;
        }

        // GET: api/Beneficiario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficiario>>> GetBeneficiario()
        {
            return await _context.Beneficiario.Include(nameof(Persona)).ToListAsync();
        }

        // GET: api/Beneficiario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficiario>> GetBeneficiario(int id)
        {
            var beneficiario = await _context.Beneficiario.FindAsync();

            if (beneficiario == null)
            {
                return NotFound();
            }

            return beneficiario;
        }

        // GET: api/Beneficiario/PorEmpleado/5
        [HttpGet("PorEmpleado/{id}")]
        public async Task<ActionResult<IEnumerable<Beneficiario>>> GetPorEmpleado(int id)
        {
            return await _context.Beneficiario.Include(nameof(Persona)).Where(a => a.EmpleadoId == id).ToListAsync(); 
        }

        // GET: api/Beneficiario/PorEmpleado/5
        [HttpGet("PorcentajeDisponible/{id}")]
        public async Task<ActionResult<int>> GetPorcentajeDisponible(int id)
        {
            int disponible = 100;
            IEnumerable<Beneficiario> bene =  await _context.Beneficiario.Where(a => a.EmpleadoId == id).ToListAsync();
            return 100 - bene.Sum(a=>a.PorcentajeParticipacion);
        }

        // POST: api/Beneficiario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beneficiario>> PostBeneficiario(Beneficiario beneficiario)
        {
            int empleadoId = (int)beneficiario.EmpleadoId;
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC InsertBeneficiario null, @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8",
                parameters: new[] { empleadoId.ToString(), beneficiario.Persona.Nombre, beneficiario.Persona.Apellidos,
                    beneficiario.Persona.FechaNacimiento.ToShortDateString(), beneficiario.Persona.CURP,
                    beneficiario.Persona.SSN, beneficiario.Persona.Telefono,
                    beneficiario.Persona.Nacionalidad, beneficiario.PorcentajeParticipacion.ToString() });

            return CreatedAtAction(nameof(GetBeneficiario), new { id = beneficiario.BeneficiarioId }, beneficiario);
        }

        // DELETE: api/Beneficiario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiario(int id)
        {
            var beneficiario = await _context.Beneficiario.FindAsync(id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteBeneficiario @p0", parameters: id);


            return NoContent();
        }

        private bool BeneficiarioExists(int id)
        {
            return _context.Beneficiario.Any(e => e.BeneficiarioId == id);
        }
    }
}
