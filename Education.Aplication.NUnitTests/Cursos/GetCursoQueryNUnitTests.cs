using AutoFixture;
using AutoMapper;
using Education.Aplication.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.Cursos;

[TestFixture]
public class GetCursoQueryNUnitTests
{
    private GetCursoQuery.GetCursoQueryHandler handlerAllCursos;

    [SetUp]
    public void SetUp()
    {
        var fixture = new Fixture();
        var cursoRecords = fixture.CreateMany<Curso>().ToList();

        cursoRecords.Add(
            fixture.Build<Curso>()
            .With(tr => tr.CursoId, Guid.Empty)
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

        handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(contextFake, mapper);

    }

    [Test]
    public async Task GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
    {
        GetCursoQuery.GetCursoQueryRequest request = new();

        var resultados = await handlerAllCursos.Handle(request, new CancellationToken());

        Assert.IsNotNull(resultados);
    }
}
 