using Domain.Models;

namespace Application.Models.Members.Responses;

public record MembersPaginationResult(int Next, int Previous, int TotalCount, IEnumerable<Member>? Members);

