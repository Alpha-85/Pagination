
using Application.Members.Queries;
using Application.Models.Members.Requests;
using Application.Models.Members.Responses;
using Domain.Models;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using WebApp.Controllers;
using Xunit;

namespace Application.UnitTests.Controllers;

public class MemberControllerTests
{
    private readonly MemberController _sut;
    private readonly IMediator _mediator = Substitute.For<IMediator>();

    public MemberControllerTests()
    {
        _sut = new MemberController(_mediator);
    }

    [Fact]
    public async Task Member_Controller_Get_Should_Return_StatusCode_200OK()
    {
        // Arrange
        _mediator.Send(Arg.Any<GetMembersQuery>())
            .Returns(new MembersPaginationResult(1,1,10,new List<Member>()));

        // Act
        var result = await _sut.Get(new MembersRequest(1, 10));

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
}
