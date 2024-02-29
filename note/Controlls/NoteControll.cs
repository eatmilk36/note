using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace note.Controlls
{
    public class NoteControll : Controller
    {
        private readonly IMediator _mediator;

        public NoteControll(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
