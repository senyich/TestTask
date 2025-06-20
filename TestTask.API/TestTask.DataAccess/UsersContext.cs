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
            new UserType { Id = 1, Name = "Администратор" },
            new UserType { Id = 2, Name = "Пользователь" },
            new UserType { Id = 3, Name = "Гость" }
        );
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "User1", TypeId = 1 },
            new User { Id = 2, Name = "User2", TypeId = 2 },
            new User { Id = 3, Name = "User3", TypeId = 3 },
            new User { Id = 4, Name = "User4", TypeId = 3 },
            new User { Id = 5, Name = "User5", TypeId = 1 }
        );
    }
    
}