using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;
[Table(nameof(characters))]
public class characters
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(120)]
    public string LastName { get; set; }
    
    public int CurrentWei { get; set; }
    
    public int MaxWeight { get; set; }
    
    public ICollection<character_titles> CharacterTitles { get; set; } 
    = new HashSet<character_titles>();
    
    public ICollection<backpacks> BackpacksCollection { get; set; } 
        = new HashSet<backpacks>();
}