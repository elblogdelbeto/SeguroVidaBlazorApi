using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosBlazorApp.Server.Data;
using SegurosBlazorApp.Shared.Models;

namespace SegurosBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly APIcontext _context;

        public EmpleadoController(APIcontext context)
        {
            _context = context;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context.Empleado.Include(nameof(Persona)).ToListAsync();
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empleado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC InsertEmpleado null, @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
                parameters: new[] { empleado.Persona.Nombre, empleado.Persona.Apellidos, 
                    empleado.Persona.FechaNacimiento.ToShortDateString(), empleado.Persona.CURP, 
                    empleado.Persona.SSN, empleado.Persona.Telefono, 
                    empleado.Persona.Nacionalidad, empleado.NumeroEmpleado.ToString() });
            
            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.EmpleadoId }, empleado);
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmpleado @p0", parameters: id);

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.EmpleadoId == id);
        }
    }
}
