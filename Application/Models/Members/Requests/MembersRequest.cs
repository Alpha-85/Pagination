namespace Application.Models.Members.Requests;

public record MembersRequest
{
    public int? Next { get; init; }
    public int? PageSize { get; set; }

}


