using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.DTOs;

namespace WebApplication2.Services;

public class DbService
{
    private readonly ApplicationContext _context;

    public DbService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<CharacterDTO?> GetCharacterInfo(int id)
    {
        var info = await _context.CharactersEnumerable
            .Where(c => c.Id == id)
            .Select(c => new CharacterDTO()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                CurrentWeight = c.CurrentWei,
                MaxWeight = c.MaxWeight,

                BackPackItems = c.BackpacksCollection.Select(b => new ItemDTO() {
                    Name = b.Item.Name,
                    ItemWeight = b.Item.Weight,
                    Amount = b.Amount
                }).ToList(),
                
                Titiles = c.CharacterTitles.Select(ct=> new TitleDTO()
                {
                    Title = ct.Title.Name,
                    AquiredAt = ct.AcquiredAt
                }).ToList()


            }).FirstOrDefaultAsync();


        return info;
    }

    public async Task<bool> DoesCharacterExist(int id)
    {
        var characterExists = await _context.CharactersEnumerable.AnyAsync(c => c.Id == id);
        return characterExists;
    }

    public async Task AddItemsToCharacter(List<int> IDs,int characterId)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                foreach (var givenId in IDs)
                {
                    var itemBackpack = new backpacks()
                    {
                        ItemId = givenId,
                        CharacterId = characterId
                    };
                    
                    
                    await _context.BackpacksEnumerable.AddAsync(itemBackpack);
                    await _context.SaveChangesAsync();
                }
                
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

    }

    public async Task<bool> DoesItemExist(List<int> IDs)
    {

        foreach (var id in IDs)
        {
            var res = await _context.ItemsEnumerable.FindAsync(id);
            if (res==null)
            {
                return false;
            }
        }
        return true;
    }

    public async Task<bool> DoesCharacterIsStrongEnough(List<int> IDs,int characterId)
    {
        var ziomek = await _context.CharactersEnumerable.Where(characters => characterId == characters.Id).FirstOrDefaultAsync();

        int maxWe = ziomek.MaxWeight;


        int suma = 0;
        foreach (var id in IDs)
        {
            var item = await _context.ItemsEnumerable.Where(items => items.Id == id).FirstOrDefaultAsync();
            suma += item.Weight;
        }
        if (suma> maxWe)
        {
            return false;
        }
        return true;


    }






}