using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using _ = ContosoUniversity.Shared.Features.Courses;


namespace ContosoUniversity.Server.Features.Courses
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator) => _mediator = mediator;

        [HttpGet("Create")] public Task<_.Create.Command> Create([FromRoute] _.Create.Query query) => _mediator.Send(query);
        [HttpPost("Create")] public Task<int> Create(_.Create.Command query) => _mediator.Send(query);

        [HttpGet("Delete/{id:int}")] public Task<_.Delete.Command> Delete([FromRoute] _.Delete.Query query) => _mediator.Send(query);
        [HttpPost("Delete/{id:int}")] public Task Delete(_.Delete.Command query) => _mediator.Send(query);

        [HttpGet("{id:int}")] public Task<_.Details.Model> Details([FromRoute] _.Details.Query query) => _mediator.Send(query);

        [HttpGet("Edit/{id:int}")] public Task<_.Edit.Command> Edit([FromRoute] _.Edit.Query query) => _mediator.Send(query);
        [HttpPost("Edit/{id:int}")] public Task Edit(_.Edit.Command query) => _mediator.Send(query);

        [HttpGet] public Task<_.Index.Result> Index([FromQuery] _.Index.Query query) => _mediator.Send(query);
    }
}
