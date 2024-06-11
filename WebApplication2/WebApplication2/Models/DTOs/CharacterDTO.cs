namespace WebApplication2.Models.DTOs;

public class CharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public IEnumerable<ItemDTO> BackPackItems { get; set; }
    public IEnumerable<TitleDTO> Titiles { get; set; }
}

public class ItemDTO
{
    public string Name { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }

   
}

public class TitleDTO
{
    public string Title { get; set; }
    public DateTime AquiredAt { get; set; }
}