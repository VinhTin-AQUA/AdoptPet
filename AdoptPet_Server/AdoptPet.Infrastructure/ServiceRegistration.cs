using AdoptPet.Application.Interfaces;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Domain.Settings;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Repositories;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptPet.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdoptPetDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("AdoptPet.API"));
            }, ServiceLifetime.Transient);
                
            // identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AdoptPetDbContext>() // provide our context
                .AddDefaultTokenProviders() // create email for email confirmation
                .AddRoles<IdentityRole>() // be able to add roles
                .AddRoleManager<RoleManager<IdentityRole>>() // be able to make use of RoleManager
                .AddSignInManager<SignInManager<AppUser>>() // make use of sign in manager
                .AddUserManager<UserManager<AppUser>>(); // make use of user manager to create user

            // mail service
            var emailConfig = configuration
                    .GetSection("EmailConfiguration")
                    .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig!);
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddTransient<VolunteerRoleService>();

            // repositories
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGenericRepository<Breed>, BreedRepository>();
            services.AddTransient<IGenericRepository<Colour>, ColourRepository>();
            services.AddTransient<IGenericRepository<Donor>, DonorRepository>();
            services.AddTransient<IGenericRepository<DonorPet>, DonorPetRepositories>();
            services.AddTransient<IGenericRepository<DonorPetAudit>, DonorPetAuditRepositories>();
            services.AddTransient<IGenericRepository<Location>, LocationRepository>();
            services.AddTransient<IGenericRepository<Owner>, OwnerRepository>();
            services.AddTransient<IGenericRepository<Pet>, PetRepository>();
            


            // services
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<ContextSeedService>();

            return services;
        }
    }
}
