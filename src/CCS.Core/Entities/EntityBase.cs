using System.ComponentModel.DataAnnotations;

namespace CCS.Core.Entities;

public abstract class EntityBase<TKey> where TKey : struct
{
    [Key]
    public TKey Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = null;
}
