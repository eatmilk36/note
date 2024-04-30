using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using note.Entities.zero;

namespace note.Applicontion.Zero;

public class ZeroListQueryHandler : IRequestHandler<ZeroListQuery, List<ZeroListQueryResponse>>
{
    private readonly ZeroDbContext _zeroDbContext;

    public ZeroListQueryHandler(ZeroDbContext zeroDbContext)
    {
        _zeroDbContext = zeroDbContext;
    }

    public async Task<List<ZeroListQueryResponse>> Handle(ZeroListQuery request, CancellationToken cancellationToken)
    {
        var firstOrDefault = await _zeroDbContext.Department.FirstOrDefaultAsync(cancellationToken);
        Console.WriteLine(JsonConvert.SerializeObject(firstOrDefault));
        return new List<ZeroListQueryResponse>();
    }
}