using AutoMapper;
using Education.Application.DTO;
using Education.Domain;

namespace Education.Aplication.Helper;

public class MappingTest : Profile
{
    public MappingTest()
    {
        CreateMap<Curso, CursoDTO>();
    }
}
