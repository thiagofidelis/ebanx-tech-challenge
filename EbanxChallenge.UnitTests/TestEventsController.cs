using System.Threading.Tasks;
using EbanxChallenge.API.Controllers;
using EbanxChallenge.Domain.Models;
using EbanxChallenge.Domain.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EbanxChallenge.UnitTests;

public class TestEventsController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatucCode200()
    {
        // arrange
        var eventServiceMock = new Mock<IEventService>();

        //eventServiceMock.Setup();

        //var sut = new EventsController(eventServiceMock.Object);

        // act
        //var result = await sut.Get(10);

        // assert
        // result.Should().BeOfType<OkObjectResult>();

        // var okObjectResult = (OkObjectResult)result;
        // okObjectResult.StatusCode.Should().Be(200);
        // okObjectResult.Value.Should().Be(100);
    }
}