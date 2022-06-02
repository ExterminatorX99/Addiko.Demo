using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.DB;
using Demo.Model;

namespace Demo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PrimateljiController : ControllerBase
	{
		private readonly AppDbContext _context;

		public PrimateljiController(AppDbContext context)
		{
			_context = context;
		}

		// GET: api/Primatelji
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Primatelj>>> GetPrimatelji()
		{
			if (_context.Primatelji == null)
			{
				return NotFound();
			}

			return await _context.Primatelji.ToListAsync();
		}

		// GET: api/Primatelji/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Primatelj>> GetPrimatelj(Guid id)
		{
			if (_context.Primatelji == null)
			{
				return NotFound();
			}

			Primatelj? primatelj = await _context.Primatelji.FindAsync(id);

			if (primatelj == null)
			{
				return NotFound();
			}

			return primatelj;
		}

		// PUT: api/Primatelji/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPrimatelj(Guid id, Primatelj primatelj)
		{
			if (id != primatelj.Id)
			{
				return BadRequest();
			}

			_context.Entry(primatelj).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PrimateljExists(id))
				{
					return NotFound();
				}

				throw;
			}

			return NoContent();
		}

		// POST: api/Primatelji
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Primatelj>> PostPrimatelj(Primatelj primatelj)
		{
			if (_context.Primatelji == null)
			{
				return Problem("Entity set 'AppDbContext.Primatelji'  is null.");
			}

			_context.Primatelji.Add(primatelj);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPrimatelj", new { id = primatelj.Id }, primatelj);
		}

		// DELETE: api/Primatelji/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePrimatelj(Guid id)
		{
			if (_context.Primatelji == null)
			{
				return NotFound();
			}

			Primatelj? primatelj = await _context.Primatelji.FindAsync(id);
			if (primatelj == null)
			{
				return NotFound();
			}

			_context.Primatelji.Remove(primatelj);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PrimateljExists(Guid id)
		{
			return (_context.Primatelji?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
