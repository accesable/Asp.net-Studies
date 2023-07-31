namespace MvcApp.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options){

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<PhoneModel> PhoneModels{get;set;}
    public DbSet<Brand> Brands {get;set;}
    // dotnet aspnet-codegenerator controller  -m PhoneModel -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout

}