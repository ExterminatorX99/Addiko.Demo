using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.DB;
using Demo.Model;

namespace Demo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PorukeController : ControllerBase
	{
		private readonly AppDbContext _context;

		public PorukeController(AppDbContext context)
		{
			_context = context;
		}

		// GET: api/Poruke
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Poruka>>> GetPoruke()
		{
			if (_context.Poruke == null)
			{
				return NotFound();
			}

			return await _context.Poruke.ToListAsync();
		}

		// GET: api/Poruke/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Poruka>> GetPoruka(Guid id)
		{
			if (_context.Poruke == null)
			{
				return NotFound();
			}

			Poruka? poruka = await _context.Poruke.FindAsync(id);

			if (poruka == null)
			{
				return NotFound();
			}

			return poruka;
		}

		// PUT: api/Poruke/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPoruka(Guid id, Poruka poruka)
		{
			if (id != poruka.Id)
			{
				return BadRequest();
			}

			_context.Entry(poruka).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PorukaExists(id))
				{
					return NotFound();
				}

				throw;
			}

			return NoContent();
		}

		// POST: api/Poruke
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Poruka>> PostPoruka(Poruka poruka)
		{
			if (_context.Poruke == null)
			{
				return Problem("Entity set 'AppDbContext.Poruke'  is null.");
			}

			_context.Poruke.Add(poruka);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPoruka", new { id = poruka.Id }, poruka);
		}

		// DELETE: api/Poruke/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePoruka(Guid id)
		{
			if (_context.Poruke == null)
			{
				return NotFound();
			}

			Poruka? poruka = await _context.Poruke.FindAsync(id);
			if (poruka == null)
			{
				return NotFound();
			}

			_context.Poruke.Remove(poruka);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PorukaExists(Guid id)
		{
			return (_context.Poruke?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
