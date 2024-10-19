using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Domain.Common;

public class AutoIncrementedEntity<T>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public T Id { get; private set; }
}