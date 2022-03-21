using Application.Common.Interfaces;
using Application.Members.Queries;
using Application.Models.Members.Requests;
using Application.Models.Members.Responses;
using Application.UnitTests.Helpers;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Application.UnitTests.Handlers;

public class GetMembersQueryHandlerTests
{
    private readonly GetMembersQueryHandler _sut;
    private readonly IApplicationDbContext _applicationDbContext = DbContextHelpers.GetApplicationDbContext();
    private readonly IDataFakerService _fakerService = Substitute.For<IDataFakerService>();
    private readonly IFixture _fixture = new Fixture();

    public GetMembersQueryHandlerTests()
    {
        _sut = new GetMembersQueryHandler(_applicationDbContext, _fakerService);
    }

    [Fact]
    public async Task GetMembersQueryHandler_Should_Return_A_PaginationResult()
    {
        // Arrange
        var request = new GetMembersQuery(new MembersRequest(1, 10));
        var members = _fixture.AddMembers();
        _fakerService.GenerateMemberData().Returns(members);

        // Act
        var result = await _sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().BeAssignableTo<MembersPaginationResult>();
        result.TotalCount.Should().Be(10);
    }

    [Theory]
    [InlineData(1, 10)]
    [InlineData(2, 20)]
    [InlineData(1, 100)]
    [InlineData(6, 10)]
    public async Task GetMembersQueryHandler_Should_Return_Correct_Values(int next, int pageSize)
    {
        // Arrange
        var request = new GetMembersQuery(new MembersRequest(next, pageSize));

        var members = _fixture.AddMembers();

        _fakerService.GenerateMemberData().Returns(members);

        // Act
        var result = await _sut.Handle(request, CancellationToken.None);

        // Assert
        result.TotalCount.Should().Be(pageSize);
        result.Next.Should().Be(next + 1);
        result.Previous.Should().Be(next);
    }
}
