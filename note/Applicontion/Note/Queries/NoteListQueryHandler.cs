using Atlas.Com.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace note.Applicontion.Note.Queries
{
    public class NoteListQueryHandler : IRequestHandler<NoteListQuery, NoteListQueryResponse>
    {
        private readonly NoteDbContext _context;

        public NoteListQueryHandler(NoteDbContext context)
        {
            _context = context;
        }

        public async Task<NoteListQueryResponse> Handle(NoteListQuery request, CancellationToken cancellationToken)
        {
            var a = await _context.Note.ToListAsync(cancellationToken);

            return new NoteListQueryResponse
            {
                Notes = a.Select(x => new Dtos.NoteDto { Id = x.Id, Title = x.Title, Content = x.Content }).ToList(),
            };
        }
    }
}