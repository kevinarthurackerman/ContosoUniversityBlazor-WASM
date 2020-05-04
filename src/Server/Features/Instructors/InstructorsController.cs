using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using _ = ContosoUniversity.Shared.Features.Instructors;

namespace ContosoUniversity.Server.Features.Courses
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController
    {
        private readonly IMediator _mediator;

        public InstructorsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("Create")] public Task<_.CreateEdit.Command> Create([FromQuery] _.CreateEdit.Query query) => _mediator.Send(query);
        [HttpPost("Create")] public Task Create(_.CreateEdit.Command query) => _mediator.Send(query);

        [HttpGet("Delete/{id:int}")] public Task<_.Delete.Command> Delete([FromRoute] _.Delete.Query query) => _mediator.Send(query);
        [HttpPost("Delete/{id:int}")] public Task Delete(_.Delete.Command query) => _mediator.Send(query);

        [HttpGet("{id:int}")] public Task<_.Details.Model> Details([FromRoute] _.Details.Query query) => _mediator.Send(query);

        [HttpGet("Edit/{id:int}")] public Task<_.CreateEdit.Command> Edit([FromRoute] _.CreateEdit.Query query) => _mediator.Send(query);
        [HttpPost("Edit/{id:int}")] public Task Edit(_.CreateEdit.Command query) => _mediator.Send(query);

        [HttpGet] public Task<_.Index.Model> Index([FromQuery] _.Index.Query query) => _mediator.Send(query);

        [HttpGet("Info/{id:int}")]
        [HttpGet("Info/{id:int}/{courseId:int}")]
        public Task<_.Index.Model> Info([FromRoute] _.Index.Query query) => _mediator.Send(query);
    }
}
