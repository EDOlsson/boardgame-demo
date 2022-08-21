using Boardgames.Api.Models;
using Boardgames.DomainLayer;
using Boardgames.DomainLayer.Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boardgames.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    readonly DomainFacade _domainFacade;

    public BaseController(DomainFacade domainFacade)
    {
        _domainFacade = domainFacade;
    }
    protected DomainFacade TheDomainFacade => _domainFacade;

    protected AuthenticatedContext BoardgameCaller => new ApiAuthenticatedContext();
}
