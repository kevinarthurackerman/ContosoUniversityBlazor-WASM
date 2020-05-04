using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using _ = ContosoUniversity.Shared.Features.About;


namespace ContosoUniversity.Server.Features.Courses
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator) => _mediator = mediator;

        [HttpGet] public Task<_.Index.Result> Index([FromQuery] _.Index.Query query) => _mediator.Send(query);
    }
}
