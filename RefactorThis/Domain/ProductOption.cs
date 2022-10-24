using System.ComponentModel.DataAnnotations.Schema;

namespace RefactorThis.Domain;

public class ProductOption
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}