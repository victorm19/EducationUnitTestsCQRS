namespace Education.Application.DTO;

public class CursoDTO
{
    public Guid CursoId { get; set; }
    public string Titulo { get; set; }
    public string Description { get; set; }
    public DateTime? FechaPublicacion { get; set; }
    public decimal Precio { get; set; }
}
