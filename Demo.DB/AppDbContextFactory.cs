using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Demo.DB
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		private const string ConnectionString = "Data Source=localhost;Initial Catalog=Demo;User ID=ap_demo;Password=ap_demo;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

		public AppDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlServer();

			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
