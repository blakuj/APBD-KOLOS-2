using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table(nameof(items))]
public class items
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    
    public int Weight { get; set; }
    
    public ICollection<backpacks> BackpacksCollection { get; set; } 
        = new HashSet<backpacks>();
    
}