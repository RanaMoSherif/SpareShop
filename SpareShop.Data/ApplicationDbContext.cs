using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SpareShop.Domain.Entities;

// ReSharper disable UnusedMember.Local

namespace SpareShop.Data;

public class ApplicationDbContext:
    IdentityDbContext<User, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    #region ctor
    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    #endregion

    #region DbSet
    public override DbSet<User> Users => Set<User>();
    public virtual DbSet<ResetPassword> ResetPasswords => Set<ResetPassword>();
    public virtual DbSet<Brand> Brands => Set<Brand>();
    public virtual DbSet<Review> Reviews => Set<Review>();
    public virtual DbSet<ProductDemo> Products => Set<ProductDemo>();
    public virtual DbSet<Category> Categories => Set<Category>();
    public virtual DbSet<CreditCard> CreditCards => Set<CreditCard>();
    public virtual DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public virtual DbSet<OrderHeader> OrderHeaders => Set<OrderHeader>();
    public virtual DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();

    #endregion

    #region OnConfiguring
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //var connectionString = config.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
            //var appPath = Directory.GetParent(Environment.CurrentDirectory)?.FullName;
            
            var dbPath = Path.Join(Environment.CurrentDirectory, "SpareShopDatabase.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

    #endregion

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<OrderDetail>().HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);

        builder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);

        //Change Identity Schema and Table Names
        builder.Entity<User>().ToTable("Users");
        builder.Entity<IdentityRole<Guid>>().ToTable("Roles");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        builder.Entity<IdentityRoleClaim<Guid>> ().ToTable("RoleClaims");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
               //.HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
    }

    #endregion

}