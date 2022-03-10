using Application.Common.Interfaces;
using Application.Models.Members.Responses;
using MediatR;

namespace Application.Members.Queries;

public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, MembersPaginationResult>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IDataFakerService _fakerService;

    public GetMembersQueryHandler(IApplicationDbContext context, IDataFakerService dataService)
    {
        _applicationDbContext = context ?? throw new ArgumentNullException(nameof(context));
        _fakerService = dataService ?? throw new ArgumentNullException(nameof(dataService));
    }
    public async Task<MembersPaginationResult> Handle(GetMembersQuery request, CancellationToken cancellationToken)
    {
        var page = request.Request.Next ?? 0;
        var pageSize = request.Request.PageSize ?? 10;


        if (!_applicationDbContext.Members.Any())
        {
            var members = await _fakerService.GenerateMemberData();

            foreach (var member in members)
            {
                _applicationDbContext.Members.Add(member);
            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        var result = _applicationDbContext.Members
            .Select(member => member)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsQueryable();

        var totalCount = result.Count();

        return new MembersPaginationResult(page +1, page  , totalCount, result);

    }
}
