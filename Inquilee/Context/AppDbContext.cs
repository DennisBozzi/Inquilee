using Inquilee.Models;
using Microsoft.EntityFrameworkCore;

namespace Inquilee.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    private DbSet<User> Users { get; set; }
}