using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Data
{
    public class AdoptPetDbContext : IdentityDbContext<AppUser>
    {
        public AdoptPetDbContext(DbContextOptions<AdoptPetDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // loại bỏ tiền tố AspNet của tên Table. Ví dụ: AspNetUsers => Users
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (string.IsNullOrEmpty(tableName) == false && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName[6..]);
                }
            }

            // sử lý decimal
            modelBuilder.Entity<Donor>()
                .Property(d => d.TotalDonation)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<DonorPet>()
              .Property(d => d.TotalDonation)
              .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<DonorPetAudit>()
              .Property(d => d.NewTotalDonation)
              .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<DonorPetAudit>()
              .Property(d => d.OldTotalDonation)
              .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Pet>()
               .Property(d => d.PetWeight)
               .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<PetAudit>()
             .Property(d => d.PetWeight)
             .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<DonorPet>()
              .HasIndex(pc => new { pc.PetId, pc.DonorId })
              .IsUnique();
        }

        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonorPet> DonorPets { get; set; }
        public DbSet<DonorPetAudit> DonorPetAudits { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetAudit> PetAudits { get; set; }
        public DbSet<PetImage> PetImages { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<VolunteerAudit> VolunteerAudits { get; set; }
        public DbSet<VolunteerRole> VolunteerRoles { get; set; }
        public DbSet<VolunteerRoleXVolunteer> VolunteerRoleXVolunteers { get; set; }
    }
}
