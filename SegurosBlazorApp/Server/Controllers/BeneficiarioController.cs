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
    [Route("api/[controller]")]
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
            var beneficiario = await _context.Beneficiario.FindAsync(id);

            if (beneficiario == null)
            {
                return NotFound();
            }

            return beneficiario;
        }

        // PUT: api/Beneficiario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiario(int id, Beneficiario beneficiario)
        {
            if (id != beneficiario.BeneficiarioId)
            {
                return BadRequest();
            }

            _context.Entry(beneficiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiarioExists(id))
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

        // POST: api/Beneficiario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beneficiario>> PostBeneficiario(Beneficiario beneficiario)
        {
            _context.Beneficiario.Add(beneficiario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficiario", new { id = beneficiario.BeneficiarioId }, beneficiario);
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

            _context.Beneficiario.Remove(beneficiario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficiarioExists(int id)
        {
            return _context.Beneficiario.Any(e => e.BeneficiarioId == id);
        }
    }
}
