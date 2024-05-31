﻿using AdoptPet.Application.Interfaces;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Application.Interfaces.IService;
using AdoptPet.Application.Profiles;
using AdoptPet.Domain.Entities;
using AdoptPet.Domain.Settings;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Repositories;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerRoles.Infrastructure.Repositories;

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

            //AutoMapper
            services.AddAutoMapper(typeof(PetImageMappingProfile).Assembly);
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


            // service
            services.AddTransient< IGenericService<VolunteerRole> ,VolunteerRoleService >();
            services.AddScoped< IGenericService<Colour>, ColourService >();
            services.AddTransient< IGenericService <Donor>, DonorService >();
            services.AddTransient< IGenericService <DonorPet>, DonorPetService >();
            services.AddTransient< IGenericService <DonorPetAudit>, DonorPetAuditService >();
            services.AddTransient< IGenericService <Owner>, OwnerService >();
            services.AddTransient< IGenericService <Location>, LocationService >();
            services.AddTransient< IGenericService <Volunteer>, VolunteerService >();
            services.AddTransient< IPetService, PetService >();
            services.AddTransient<IGenericServiceWithImage<Breed>, BreedService>();

            // repositories
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGenericRepository<Breed>, BreedRepository>();
            services.AddTransient<IGenericRepository<Colour>, ColourRepository>();
            services.AddTransient<IGenericRepository<Donor>, DonorRepository>();
            services.AddTransient<IGenericRepository<DonorPet>, DonorPetRepository>();
            services.AddTransient<IGenericRepository<DonorPetAudit>, DonorPetAuditRepository>();
            services.AddTransient<IGenericRepository<Location>, LocationRepository>();
            services.AddTransient<IGenericRepository<Owner>, OwnerRepository>();
            services.AddTransient<IPetImageRepository, PetImageRepository>();

            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<IVolunteerRoleRepository, VolunteerRoleRepository>();
            services.AddTransient<IGenericRepository<Volunteer>, VolunteerRepository>();
            services.AddTransient<VolunteerRoleXVolunteerRepository>();



            // services
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ContextSeedService>();

            return services;
        }
    }
}
