using Xunit;
using Shouldly;
using System.Threading.Tasks;
using Boardgames.DomainLayer;
using DomainFacadeTests.ServiceLocators;
using Boardgames.DomainLayer.Managers.Models;
using DomainFacadeTests.TestDoubles.Stubs;
using DomainFacadeTests.TestMediators;

namespace DomainFacadeTests;

public class CreateBoardgameTests
{
    readonly TestMediator _testMediator = new TestMediator();
    readonly DomainFacade _domainFacade;
    readonly AuthenticatedContext _authContext = new AuthContextStub();

    public CreateBoardgameTests()
    {
        var testServiceLocator = new TestServiceLocator(_testMediator);
        _domainFacade = new DomainFacade(testServiceLocator);

    }
    [Fact]
    public void AllIsRightInTheWorld()
    {
        (1 + 1).ShouldBe(2);
    }

    [Fact]
    public async Task CallIsMadeToBoardgameGeek()
    {
        var newBoardgame = new BoardgameForCreate("No Thanks!", "Card game", 8);
        var actualResponse = await _domainFacade.CreateNewBoardgameAsync(newBoardgame, _authContext);

        var actualRequestUrl = _testMediator.GetLastReceivedRequest().RequestUri;

        actualRequestUrl.ShouldBe(new System.Uri("https://boardgamegeek.com/xmlapi/search?search=No%20Thanks%21"));
    }
}