using AutoFixture;
using AutoMapper;
using Education.Aplication.Helper;
using Education.Application.Cursos;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Aplication.Cursos;

[TestFixture]
public class GetCursoByIdQueryNUnitTests
{
    private GetCursoByIdQuery.GetCursoByIdQueryHandler handlerCurso;
    private Guid cursoId;

    [SetUp]
    public void SetUp()
    {
        cursoId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        var fixture = new Fixture();
        var cursoRecords = fixture.CreateMany<Curso>().ToList();

        cursoRecords.Add(
            fixture.Build<Curso>()
            .With(tr => tr.CursoId, cursoId)
            .Create()
            );


        var options = new DbContextOptionsBuilder<EducationDbContext>()
            .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
            .Options;

        var contextFake = new EducationDbContext(options);

        contextFake.Cursos.AddRange(cursoRecords);

        contextFake.SaveChanges();

        var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingTest()));

        var mapper = mapConfig.CreateMapper();

        handlerCurso = new GetCursoByIdQuery.GetCursoByIdQueryHandler(contextFake, mapper);

    }

    [Test]
    public async Task GetCursoByIdQueryHandler_InputCursoId_ReturnsNotNull()
    {
        GetCursoByIdQuery.GetCursoByIdQueryRequest request = new()
        {
            Id = cursoId
        };

        var resultados = await handlerCurso.Handle(request, new CancellationToken());

        Assert.IsNotNull(resultados);
    }
}
