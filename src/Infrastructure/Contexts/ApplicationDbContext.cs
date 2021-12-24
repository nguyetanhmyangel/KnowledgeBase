using Application.Interfaces.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Application.Interfaces.Shared;
using Domain.Abstractions;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }


        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();


        public DbSet<AppCommand> AppCommands { get; set; } = null!;
        public DbSet<AppCommandFunction> AppCommandFunctions { get; set; } = null!;
        public DbSet<ActivityLog> ActivityLogs { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Function> Functions { get; set; } = null!;
        public DbSet<Knowledge> Knowledge { get; set; } = null!;
        public DbSet<Label> Labels { get; set; } = null!;
        public DbSet<LabelKnowledge> LabelInKnowledge { get; set; } = null!;
        public DbSet<AppPermission> AppPermissions { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;
        public DbSet<Vote> Votes { get; set; } = null!;
        public DbSet<Attachment> Attachments { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var modified = ChangeTracker.Entries()
                .Where(e => e.State is EntityState.Modified or EntityState.Added);
            foreach (var item in modified)
            {
                if (item.Entity is IAuditableBaseEntity changedOrAddedItem)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreateDate = _dateTime.NowUtc;
                        changedOrAddedItem.CreatedBy = _authenticatedUser.UserId;
                    }
                    else
                    {
                        changedOrAddedItem.LastModifiedDate = _dateTime.NowUtc;
                        changedOrAddedItem.LastModifiedBy = _authenticatedUser.UserId;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedOn = _dateTime.NowUtc;
        //                entry.Entity.CreatedBy = _authenticatedUser.UserId;
        //                break;

        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedOn = _dateTime.NowUtc;
        //                entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
        //                break;
        //        }
        //    }
        //    if (_authenticatedUser.UserId == null)
        //    {
        //        return await base.SaveChangesAsync(cancellationToken);
        //    }
        //    else
        //    {
        //        return await base.SaveChangesAsync(_authenticatedUser.UserId);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.HasSequence("KnowledgeBaseSequence");

            builder.Entity<AppCommandFunction>()
                .HasIndex(p => new { p.AppCommandId, p.FunctionId })
                .IsUnique(true);

            builder.Entity<AppPermission>()
                .HasIndex(p => new { p.AppCommandId, p.FunctionId, p.RoleId })
                .IsUnique(true);

            builder.Entity<LabelKnowledge>()
                .HasIndex(p => new { p.LabelId, p.KnowledgeId })
                .IsUnique(true);

        }
    }
}