using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;
[PrimaryKey(nameof(CharacterId),nameof(TitleId))]

[Table(nameof(character_titles))]
public class character_titles
{
    public int CharacterId { get; set; }
    [ForeignKey(nameof(CharacterId))] public characters Character { get; set; } = null!;
    public int TitleId { get; set; }
    [ForeignKey(nameof(TitleId))] public titles Title { get; set; } = null!;

    public DateTime AcquiredAt { get; set; }
}