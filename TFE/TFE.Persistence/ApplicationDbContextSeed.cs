using Microsoft.AspNetCore.Identity;
using TFE.Infrastructure.Identity;

namespace TFE.Infrastructure;

public class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole<int>> roleManager)
    {
        var defaultUser = new ApplicationUser() { UserName = "user", Email = "user@tfe.ru" };
        var identityResult = await userManager.CreateAsync(defaultUser, "Password@1234");

        const string administratorRole = "Administrator";
        await roleManager.CreateAsync(new IdentityRole<int>(administratorRole));

        const string adminEmail = "admin@tfe.ru";
        var adminUser = new ApplicationUser { UserName = "admin", Email = adminEmail };
        
        await userManager.CreateAsync(adminUser, "Password@1234");
        
        adminUser = await userManager.FindByEmailAsync(adminEmail);
        await userManager.AddToRoleAsync(adminUser, administratorRole);
    }
}