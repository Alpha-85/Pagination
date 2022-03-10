
using Application.Models.Members.Requests;
using Application.Models.Members.Responses;
using MediatR;

namespace Application.Members.Queries;

public record GetMembersQuery : IRequest<MembersPaginationResult>
{
    public MembersRequest Request { get; set; }

    public GetMembersQuery(MembersRequest request)
    {
        Request = request;
    }
}
