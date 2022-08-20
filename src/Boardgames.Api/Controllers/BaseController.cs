using Boardgames.Api.Models;
using Boardgames.DomainLayer;
using Boardgames.DomainLayer.Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boardgames.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    DomainFacade? _domainFacade;
    protected DomainFacade TheDomainFacade { get { return _domainFacade ??= new DomainFacade(); } }

    protected AuthenticatedContext BoardgameCaller => new ApiAuthenticatedContext();
}
