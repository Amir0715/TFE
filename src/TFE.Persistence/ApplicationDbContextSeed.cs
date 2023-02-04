using Microsoft.AspNetCore.Identity;
using TFE.Domain.Testing.AuthorAgregate;
using TFE.Infrastructure.Identity;

namespace TFE.Infrastructure;

public class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole<int>> roleManager)
    {
        var defaultUserProfile = new Author("DefaultUser", "DefaultUser");
        var defaultUser = new ApplicationUser() { UserName = "user", Email = "user@tfe.ru", UserProfile = defaultUserProfile};
        var identityResult = await userManager.CreateAsync(defaultUser, "Password@1234");

        const string administratorRole = "Administrator";
        await roleManager.CreateAsync(new IdentityRole<int>(administratorRole));

        var adminUserProfile = new Author("AdminUser", "AdminUser");
        const string adminEmail = "admin@tfe.ru";
        var adminUser = new ApplicationUser { UserName = "admin", Email = adminEmail, UserProfile = adminUserProfile };
        
        await userManager.CreateAsync(adminUser, "Password@1234");
        
        adminUser = await userManager.FindByEmailAsync(adminEmail);
        await userManager.AddToRoleAsync(adminUser, administratorRole);
    }
}