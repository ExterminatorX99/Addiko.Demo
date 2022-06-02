using System.ComponentModel.DataAnnotations;

namespace Demo.Model;

public class Poruka
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();

	public DateTime DatumVrijemeSlanja { get; set; }

	public string LokacijaPoruke { get; set; } = default!;

	public Primatelj Primatelj { get; set; } = default!;
}
