using System.Threading.Tasks;
using EbanxChallenge.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EbanxChallenge.UnitTests;

public class TestBalancesController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatucCode200()
    {
        // arrange
        var sut = new BalancesController();

        // act
        var result = (OkObjectResult)await sut.Get();

        // assert
        result.StatusCode.Should().Be(200);
    }
}