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
    public required int ParentCategoryId { get; set; }
    public required string ParentCategoryName { get; set; }
    [Display(Name = "Potkategorija")]
    public required string DisplayName { get; set; }
}