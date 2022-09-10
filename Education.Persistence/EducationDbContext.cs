using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence;

public class EducationDbContext : DbContext
{
    public EducationDbContext()
    {

    }

    public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
    { }

    public DbSet<Curso> Cursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
            options.UseSqlServer("Data Source=localhost; Initial Catalog=Education;user id=sa;password=Poli2016");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>()
            .Property(p => p.Precio)
            .HasPrecision(14, 2); 

        modelBuilder.Entity<Curso>()
            .HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Description = "Curso C# basico",
                    Titulo = "C# Desde cero a master",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 56
                }
            );
        
        modelBuilder.Entity<Curso>()
            .HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Description = "Curso java",
                    Titulo = "Master en Java desde las raices",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 25
                }
            );
        
        modelBuilder.Entity<Curso>()
            .HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Description = "Curso c# prubas unitarias",
                    Titulo = "Master en pruebas unitarias",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 1000
                }
            );
    }
}
