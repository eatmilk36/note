using Atlas.Com.Entities;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using StackExchange.Redis.Extensions.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<NoteDbContext>(builder =>
{
    builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), optionsBuilder =>
    {
        optionsBuilder.CommandTimeout(10);
        optionsBuilder.EnableRetryOnFailure();
    });

    builder.EnableSensitiveDataLogging().EnableDetailedErrors();
});

var redisConfig = Configuration.GetSection("Redis").Get<RedisConfig>();

var redisConfiguration = new RedisConfiguration()
{
    ConnectionString = redisConfig!.Host
};

builder.Services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

//builder.Services.AddDistributedRedisCache(options =>
//{
//    options.Configuration = redisConfig!.Host;
//});

var app = builder.Build();

app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api"), builder =>
{
    builder.UseSpa(spa =>
    {
        spa.Options.SourcePath = "ClientApp";
        spa.UseProxyToSpaDevelopmentServer("http://localhost:3333");
    });
});

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
