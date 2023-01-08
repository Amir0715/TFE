using Microsoft.AspNetCore.Identity;
using TFE.Domain.Entities;

namespace TFE.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public UserProfile? UserProfile { get; set; }
    public int? UserProfileId { get; set; }

    public ApplicationUser()
    {

    }
}