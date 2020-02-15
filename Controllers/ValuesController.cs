using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testpfe.Models;

namespace testpfe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TodoContext _context;

        public ValuesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiant>>> Get()
        {
            return await _context.TodoItems.ToListAsync();
        }
        
        // GET: api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> Get(int id)
        {
            var author = await _context.TodoItems.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }
        // PUT: api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, [Bind("Id,Name,IsComplete")]Etudiant author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;//plus de détail

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(author);
        }
       // POST: api/values
        // To protect from overposting attacks
        [HttpPost]
        public async Task<ActionResult<Etudiant>> PostAuthor([Bind("Id,Name,IsComplete")] Etudiant author)
        {
            _context.TodoItems.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = author.Id }, author);
        }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Etudiant>> DeleteAuthor(int id)
        {
            var author = await _context.TodoItems.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }
        private bool EtudiantExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
        }}