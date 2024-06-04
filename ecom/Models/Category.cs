using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ecom.Models;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Keywords { get; set; }
    [Display(Name = "Napomene")]
    public string? Note { get; set; }
    [Display(Name = "Kategorija")]
    public string? DisplayName { get; set;}
    public virtual List<SubCategory>? SubCategories { get; set; }
    public virtual List<Product>? Products { get; set; }
}