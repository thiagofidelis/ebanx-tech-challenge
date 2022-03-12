using System.Threading.Tasks;
using EbanxChallenge.API.Controllers;
using EbanxChallenge.Domain.Models;
using EbanxChallenge.Domain.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EbanxChallenge.UnitTests;

public class TestBalancesController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatucCode200()
    {
        // arrange
        var accountServiceMock = new Mock<IAccountService>();

        accountServiceMock.Setup(service => service.Get(10))
            .ReturnsAsync(new Account(10, 100));

        var sut = new BalancesController(accountServiceMock.Object);

        // act
        var result = await sut.Get(10);

        // assert
        result.Should().BeOfType<OkObjectResult>();

        var okObjectResult = (OkObjectResult)result;
        okObjectResult.StatusCode.Should().Be(200);
        okObjectResult.Value.Should().Be(100);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsStatucCode404()
    {
        // arrange
        var accountServiceMock = new Mock<IAccountService>();

        accountServiceMock.Setup(service => service.Get(10))
            .ReturnsAsync(null as Account);

        var sut = new BalancesController(accountServiceMock.Object);

        // act
        var result = await sut.Get(10);

        // assert
        result.Should().BeOfType<NotFoundObjectResult>();

        var notFoundObjectResult = (NotFoundObjectResult)result;
        notFoundObjectResult.StatusCode.Should().Be(404);
        notFoundObjectResult.Value.Should().Be(0);

    }
}