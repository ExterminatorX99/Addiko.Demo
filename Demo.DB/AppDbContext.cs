using Demo.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.DB;

public class AppDbContext : DbContext
{
	public DbSet<Primatelj>? Primatelji { get; set; }

	public DbSet<Poruka>? Poruke { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}
}
