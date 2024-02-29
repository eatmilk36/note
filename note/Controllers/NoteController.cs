using MediatR;
using Microsoft.AspNetCore.Mvc;
using note.Applicontion.Note.Queries;

namespace note.Controllers
{
    [Route("/api")]
    public class NoteController : Controller
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("List")]
        public async Task<NoteListQueryResponse> Get()
        {
            var query = new NoteListQuery();
            return await _mediator.Send(query);
        }
    }
}
