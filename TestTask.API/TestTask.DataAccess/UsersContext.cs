using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Entities;

namespace TestTask.DataAccess;

public class UsersContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserType> UserTypes { get; set; }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Type)
            .WithMany(t => t.Users)
            .HasForeignKey(u => u.TypeId);
        
        modelBuilder.Entity<UserType>().HasData(
            new UserType { Id = 1, Name = "Admin" },
            new UserType { Id = 2, Name = "User" }
        );
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Alice", TypeId = 1 },
            new User { Id = 2, Name = "Bob", TypeId = 2 }
        );
    }
    
}