using System.ComponentModel.DataAnnotations.Schema;

namespace RefactorThis.Entities;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal DeliveryPrice { get; set; }
}