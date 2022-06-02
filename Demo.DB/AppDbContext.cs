using Demo.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.DB;

public class AppDbContext : DbContext
{
	public DbSet<Primatelj> Primatelji { get; set; } = default!;

	public DbSet<Poruka> Poruke { get; set; } = default!;

	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}
}
