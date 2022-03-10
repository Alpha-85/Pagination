
using Application.Models.Members.Requests;
using Application.Models.Members.Responses;
using MediatR;

namespace Application.Members.Queries;

public record GetMembersQuery(MembersRequest Request) : IRequest<MembersPaginationResult>;
