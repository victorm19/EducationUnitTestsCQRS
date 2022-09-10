﻿using Education.Application.Cursos;
using Education.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> Get()
        {
            return await _mediator.Send(new GetCursoQuery.GetCursoQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCursoCommand.CreateCursoCommandRequest command)
        {
            return await _mediator.Send(command);
        }
    }
}
