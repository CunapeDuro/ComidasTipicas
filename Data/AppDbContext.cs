using Microsoft.EntityFrameworkCore;
using ComidasTipicasAPI.Models;
namespace ComidasTipicasAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SantaCruz> SantaCruces { get; set; }
    public DbSet<LaPaz> LaPazes { get; set; }
}