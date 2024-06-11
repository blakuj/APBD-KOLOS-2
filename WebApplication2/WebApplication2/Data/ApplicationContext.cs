using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<backpacks> BackpacksEnumerable { get; set; }
    public DbSet<characters> CharactersEnumerable { get; set; }
    public DbSet<character_titles> CharacterTitlesEnumerable { get; set; }
    public DbSet<items> ItemsEnumerable { get; set; }
    public DbSet<titles> TitlesEnumerable { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<characters>().HasData(
            new characters {Id = 1, FirstName = "John",LastName = "Yakuza" ,
                CurrentWei = 43,MaxWeight = 200}
            
        );

        modelBuilder.Entity<items>().HasData(
            new items {Id = 1,Name = "Item1",Weight = 10},
            new items{Id = 2 , Name = "Item2",Weight = 11},
            new items{Id=3,Name = "Item3",Weight = 12}
        );

        modelBuilder.Entity<backpacks>().HasData(
            new backpacks {CharacterId =1,ItemId = 1,Amount = 2},
            new backpacks {CharacterId =1,ItemId = 2,Amount = 1},
            new backpacks {CharacterId =1,ItemId = 3,Amount = 3}
            );
        
        modelBuilder.Entity<titles>().HasData(
        new titles{Id = 1,Name = "Title1"},
        new titles{Id = 2,Name = "Title2"},
        new titles{Id = 3,Name = "Title3"}
            );

        modelBuilder.Entity<character_titles>().HasData(
            new character_titles{CharacterId = 1,TitleId = 1,AcquiredAt = DateTime.Now},
            new character_titles{CharacterId = 1,TitleId = 2,AcquiredAt = DateTime.Now.AddDays(1)},
            new character_titles{CharacterId = 1,TitleId = 3,AcquiredAt = DateTime.Now.AddDays(2)}
            
            );
    }
}