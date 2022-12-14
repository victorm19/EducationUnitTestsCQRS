using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos;

public class GetCursoQuery
{
    public class GetCursoQueryRequest : IRequest<List<CursoDTO>> { }


    public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<CursoDTO>>
    {
        private readonly EducationDbContext _context;
        private readonly IMapper _mapper;

        public GetCursoQueryHandler(EducationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CursoDTO>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
        {
            var cursos = await _context.Cursos.ToListAsync(cancellationToken: cancellationToken);
            return _mapper.Map<List<Curso>, List<CursoDTO>>(cursos);
        }
    }
}
