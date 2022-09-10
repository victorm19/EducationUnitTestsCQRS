using AutoFixture;
using Education.Application.Cursos;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Aplication.Cursos;

[TestFixture]
public class CreateCursoCommandNUnitTests
{
    private CreateCursoCommand.CreateCursoCommandRequestHandler handlerCreateCurso;

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

        handlerCreateCurso = new CreateCursoCommand.CreateCursoCommandRequestHandler(contextFake);

    }

    [Test]
    public async Task CreateCursoCommandRequestHandler_InputCurso_ReturnsNumber()
    {
        CreateCursoCommand.CreateCursoCommandRequest request = new ();
        request.Titulo = "Angular 14";
        request.FechaPublicacion = DateTime.Now.AddYears(1);
        request.Description = "Aprende angular desde cero hasta master";
        request.Precio = 99;

        var resultados = await handlerCreateCurso.Handle(request, new CancellationToken());

        Assert.That(resultados, Is.EqualTo(Unit.Value));
    }
}
