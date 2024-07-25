using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationTarefaCrudServer.Data;
using WebApplicationTarefaCrudServer.Entities;

namespace WebApplicationTarefaCrudServer.Controllers
{
    [Route("api/tarefa")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly Context _context;

        public TarefasController(Context context)
        {
            _context = context;
        }

        // GET: api/tarefa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetAll()
        {
            var list = await _context.Tarefa.ToListAsync();
            if (list.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return list;
            }
        }

        // GET: api/tarefa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        // PUT: api/tarefa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            if (id != tarefa.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/tarefa
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
            _context.Tarefa.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefa", new { id = tarefa.Codigo }, tarefa);
        }

        // DELETE: api/tarefa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefa.Any(e => e.Codigo == id);
        }
    }
}
