using MediatR;
using Microsoft.AspNetCore.Mvc;
using note.Applicontion.Note.Queries;
using note.Applicontion.Zero;

namespace note.Controllers
{
    [Route("/api/zero")]
    public class ZeroController : Controller
    {
        private readonly IMediator _mediator;

        public ZeroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("List")]
        public async Task<List<ZeroListQueryResponse>> Get(ZeroListQuery query)
        {
            //var query = new NoteListQuery();
            return await _mediator.Send(query);
        }
    }
}