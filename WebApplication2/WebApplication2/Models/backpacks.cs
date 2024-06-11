using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;
[PrimaryKey(nameof(CharacterId),nameof(ItemId))]

[Table(nameof(backpacks))]
public class backpacks
{
    public int CharacterId { get; set; }
    [ForeignKey(nameof(CharacterId))] public characters Character { get; set; } = null!;
    public int ItemId { get; set; }
    [ForeignKey(nameof(ItemId))] public items Item { get; set; } = null!;

    public int Amount { get; set; }
}