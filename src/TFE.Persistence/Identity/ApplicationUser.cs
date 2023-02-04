using Microsoft.AspNetCore.Identity;
using TFE.Domain.Testing.AuthorAgregate;

namespace TFE.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public Author? UserProfile { get; set; }
    public int? UserProfileId { get; set; }

    public ApplicationUser()
    {

    }
}