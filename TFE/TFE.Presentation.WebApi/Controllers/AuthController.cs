using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TFE.Application.CQRS.UserProfiles.Commands.UserProfileCreate;
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
    private readonly ISender _sender;
    
    public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ITokenClaimsService tokenClaimsService, ISender sender)
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _tokenClaimsService = tokenClaimsService ?? throw new ArgumentNullException(nameof(tokenClaimsService));
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));

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

    [HttpPost]
    public async Task<ActionResult> Registration(RegistrationDTO registrationDTO, CancellationToken cancellationToken)
    {
        var applicationUser = new ApplicationUser
        {
            Email = registrationDTO.Email,
            UserName = registrationDTO.UserName
        };

        var creationIdentityResult = await _userManager.CreateAsync(applicationUser, registrationDTO.Password);
        if (!creationIdentityResult.Succeeded) 
            return BadRequest(creationIdentityResult.Errors);
        
        var createdUser = await _userManager.FindByEmailAsync(applicationUser.Email);
        var createUserProfileCommand = new UserProfileCreateCommand(
            registrationDTO.FirstName,
            registrationDTO.LastName, 
            registrationDTO.Patronymic
        );
        var userProfileId = await _sender.Send(createUserProfileCommand, cancellationToken);
        createdUser.UserProfileId = userProfileId;
        await _userManager.UpdateAsync(createdUser);
        return Ok();
    }
}