using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RandomUser.Api.Data.Mappings;
using RandomUser.Api.Data.Models;

namespace RandomUser.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
}