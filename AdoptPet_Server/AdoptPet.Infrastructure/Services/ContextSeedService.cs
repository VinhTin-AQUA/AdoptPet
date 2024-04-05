using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class ContextSeedService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AdoptPetDbContext context;
        private readonly UserManager<AppUser> userManager;

        public ContextSeedService(RoleManager<IdentityRole> roleManager,
            AdoptPetDbContext context,
            UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.context = context;
            this.userManager = userManager;
        }

        public async Task InitializeContextAsync()
        {

            // kiểm tra có migration nào ở trạng thái pending không
            if (context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Count() > 0)
            {
                // tiến hành cập nhật migration
                await context.Database.MigrateAsync();
            }

            #region role

            if (await roleManager.Roles.AnyAsync() == false)
            {
                IdentityRole adminRole = new IdentityRole("Admin");
                IdentityRole userRole = new IdentityRole("User");

                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);
            }

            #endregion

            #region user

            if (await userManager.Users.AnyAsync() == false)
            {
                AppUser admin = new()
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    PhoneNumber = "1234567890",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                };
                await userManager.CreateAsync(admin, "admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            #endregion
        }
    }
}
