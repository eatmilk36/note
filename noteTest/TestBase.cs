using System.Threading.Tasks;
using Atlas.Com.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;

namespace Atlas.Com.Tests
{
    public class TestBase<T>
    {
        protected NoteDbContext NoteDbContext { get; set; }

        protected FormFile GivenImg(int length, string fileName)
        {
            return new FormFile(null, 0, length, string.Empty, fileName);
        }

        [SetUp]
        protected void Setup()
        {
            var options = new DbContextOptionsBuilder<NoteDbContext>()
                          .UseSqlite(SqliteConnection(nameof(NoteDbContext))).Options;

            NoteDbContext = new NoteDbContext(options);
            NoteDbContext.Database.EnsureDeleted();
            NoteDbContext.Database.EnsureCreated();
        }

        [TearDown]
        protected void Tear()
        {
            NoteDbContext.Database.EnsureDeleted();        
        }

        //protected async Task GivenUsers(params User[] user)
        //{
        //    await NoteDbContext.User.AddRangeAsync(user);

        //    await NoteDbContext.SaveChangesAsync();
        //}

        private SqliteConnection SqliteConnection(string dbContextName)
        {
            return new SqliteConnection($"Filename={dbContextName}.db");
        }
    }
}