using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Inventory
{
    [Required]
    public int Id { get; set; }

    [Required, StringLength(25, ErrorMessage = "Name cannot be longer than 25 characters.")]
    public string Name { get; set; }

    [StringLength(255, ErrorMessage = "Description cannot be longer than 100 characters.")]
    public string Description { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public int Quantity { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Price { get; set; }

    public DateTime AddedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime DeletedAt { get; set; }
}