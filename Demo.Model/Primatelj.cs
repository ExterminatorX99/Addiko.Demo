using System.ComponentModel.DataAnnotations;

namespace Demo.Model;

public class Primatelj
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();

	public string Ime { get; set; } = default!;

	public string Prezime { get; set; } = default!;

	public string BrojMobitela { get; set; } = default!;
}
