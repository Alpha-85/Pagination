using AutoFixture;
using Domain.Models;

namespace Application.UnitTests.Helper;

public static class MemberObjectBuilder
{
    public static IEnumerable<Member> AddMembers(this IFixture fixture)
    {
        var members = fixture
            .Build<Member>()
            .WithAutoProperties()
            .CreateMany(100);

        return members;
    }
}
