using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICepdi.Data;
using WebAPICepdi.Models;

namespace WebAPICepdi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentosController : ControllerBase
    {
        private readonly ILogger<MedicamentosController> _logger;
        private readonly DataContext _context;
        public MedicamentosController(ILogger<MedicamentosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetMedicamentos")]
        public async Task<ActionResult<IEnumerable<Medicamentos>>> GetMedicamentos()
        {
            return await _context.Medicamentos.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetMedicamento")]
        public async Task<ActionResult<Medicamentos>> GetMedicamento(int id)
        {
            var medicamentos = await _context.Medicamentos.FindAsync(id);
            if (medicamentos == null)
            {
                return NotFound();
            }
            return medicamentos;
        }

        [HttpPost]
        public async Task<ActionResult<Medicamentos>> PostMedicamento(Medicamentos medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetMedicamento", new { idMedicamento = medicamento.idMedicamento }, medicamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamento(int id, Medicamentos medicamento)
        {
            if (id != medicamento.idMedicamento)
            {
                return BadRequest();
            }
            _context.Entry(medicamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamento(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            _context.Medicamentos.Remove(medicamento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}