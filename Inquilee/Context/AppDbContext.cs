using Inquilee.Models;
using Microsoft.EntityFrameworkCore;

namespace Inquilee.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    private DbSet<User> Users { get; set; }
    private DbSet<Tenant> Tenants { get; set; }
    private DbSet<Residence> Residences { get; set; }
}