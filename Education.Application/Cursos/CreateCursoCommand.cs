using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;

namespace Education.Application.Cursos;

public class CreateCursoCommand
{
    public class CreateCursoCommandRequest : IRequest
    {
        public string Titulo { get; set; }
        public string Description { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public decimal Precio { get; set; }
    }

    public class CreateCursoCommandRequestValidation : AbstractValidator<CreateCursoCommandRequest>
    {
        public CreateCursoCommandRequestValidation()
        {
            RuleFor(c => c.Description).MaximumLength(200);
            RuleFor(c => c.Titulo).MaximumLength(200);
        }
    }

    public class CreateCursoCommandRequestHandler : IRequestHandler<CreateCursoCommandRequest>
    {
        private readonly EducationDbContext _context;

        public CreateCursoCommandRequestHandler(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
        {
            var curso = new Curso
            {
                CursoId = Guid.NewGuid(),
                Titulo = request.Titulo,
                Description = request.Description,
                FechaCreacion = DateTime.UtcNow,
                FechaPublicacion = request.FechaPublicacion,
                Precio = request.Precio,
            };

            await _context.Cursos.AddAsync(curso);
            var response = await _context.SaveChangesAsync();

            if (response > 0)
                return Unit.Value;
            else
                throw new Exception("No se pudo insertar el curso.");
        }
    }
}
