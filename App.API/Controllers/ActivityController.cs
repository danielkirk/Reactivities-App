using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.BLL.Activities;
using App.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List() => await _mediator.Send(new List.Query());

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Activity>> Details(Guid id) => await _mediator.Send(new Details.Query { Id = id });

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command) => await _mediator.Send(command);

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id, Delete.Command command) => await _mediator.Send(new Delete.Command { Id = id });
    }
}