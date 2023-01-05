using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFE.Domain.Interfaces;
using TFE.Infrastructure.Identity;
using TFE.WebApi.DTOs;
using TFE.WebApi.ViewModels;

namespace TFE.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenClaimsService _tokenClaimsService;

    public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ITokenClaimsService tokenClaimsService)
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _tokenClaimsService = tokenClaimsService ?? throw new ArgumentNullException(nameof(tokenClaimsService));
    }

    [HttpPost]
    public async Task<ActionResult<AuthenticateVm>> LogIn([FromBody] AuthenticateDTO authenticateDto, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(authenticateDto.Username);

        if (user == null)
        {
            return BadRequest("Bad credentials");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            authenticateDto.Password, 
            true
        );

        var authenticateVm = new AuthenticateVm
        {
            Username = authenticateDto.Username,
            IsLockedOut = result.IsLockedOut,
            IsNotAllowed = result.IsNotAllowed,
            RequiresTwoFactor = result.RequiresTwoFactor,
            Result = result.Succeeded
        };

        if (result.Succeeded)
        {
            authenticateVm.Token = await _tokenClaimsService.GetTokenAsync(authenticateDto.Username);
        }

        return authenticateVm;
    }

    [HttpPost]
    [Authorize]
    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }
}