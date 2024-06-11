using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;
[Table(nameof(titles))]
public class titles
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    
    
    public ICollection<character_titles> CharacterTitles { get; set; } 
        = new HashSet<character_titles>();

}