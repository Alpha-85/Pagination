using Domain.Models;

namespace Application.Models.Members.Responses;

public class MembersPaginationResult
{
    public int Next { get; set;}
    public int Previous { get; set;}
    public int TotalCount { get; set;}
    public IEnumerable<Member>? Members { get; set; }
}
