using CQRS_MediatR_Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR_Demo.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Product> Products { get; set; }
}
