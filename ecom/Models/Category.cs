using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Category
{
    public int Id { get; set; }
    [Display(Name = "Naziv")]
    public required string Name { get; set; }
    public required string Keywords { get; set; }
    [Display(Name = "Napomene")]
    public required string Note { get; set; }
}