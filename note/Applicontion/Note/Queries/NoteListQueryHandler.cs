using Atlas.Com.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Implementations;

namespace note.Applicontion.Note.Queries
{
    public class NoteListQueryHandler : IRequestHandler<NoteListQuery, NoteListQueryResponse>
    {
        private readonly NoteDbContext _context;
        private readonly IRedisDatabase _redisDatabase;

        public NoteListQueryHandler(NoteDbContext context,
            IRedisDatabase redisDatabase)
        {
            _context = context;
            _redisDatabase = redisDatabase;
        }

        public async Task<NoteListQueryResponse> Handle(NoteListQuery request, CancellationToken cancellationToken)
        {
            var a = await _context.Note.ToListAsync(cancellationToken);

            await SetValueAsync("Jeter", "sandy");

            await _redisDatabase.HashSetAsync("myHash", "field1", "value1");
            await _redisDatabase.HashSetAsync("myHash", new Dictionary<string, string>
            {
                { "field2", "value2" },
                { "field3", "value3" }
            });

            await _redisDatabase.ListAddToLeftAsync("myList", "item1");

            //var listRedis = new List<string> { "aa", "bb" };
            var listRedis = new string[]{ "aa", "bb" };

            await _redisDatabase.ListAddToLeftAsync<string[]>("myList", listRedis);

            return new NoteListQueryResponse
            {
                Notes = a.Select(x => new Dtos.NoteDto { Id = x.Id, Title = x.Title, Content = x.Content }).ToList(),
            };
        }

        public async Task SetValueAsync(string key, string value)
        {
            await _redisDatabase.AddAsync(key, value, TimeSpan.FromMinutes(10));
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _redisDatabase.GetAsync<string>(key);
        }
    }
}