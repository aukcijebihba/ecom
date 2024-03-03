using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class SubCategory
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "Naziv")]
    public required string Name { get; set; }
    public required string Keywords { get; set; }
    public int ParentCategoryId { get; set; }
}