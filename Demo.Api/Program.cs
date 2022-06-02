using Demo.DB;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly("Demo.DB")));

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCors();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.UseCors(policy => policy
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials());               // allow credentials

			app.Run();
		}
	}
}