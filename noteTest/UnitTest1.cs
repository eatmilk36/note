using Atlas.Com.Tests;
using note.Applicontion.Note.Queries;

namespace noteTest
{
    public class Tests : TestBase<Tests>
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1Async()
        {
            var query = new NoteListQuery();
            var handler = new NoteListQueryHandler(NoteDbContext);
            var resdponse = await handler.Handle(query, CancellationToken.None);
        }
    }
}