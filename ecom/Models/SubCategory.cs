using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ecom.Models;

public class SubCategory
{
    public int Id { get; set; }
    [Display(Name = "Potkategorija")]
    public string? Name { get; set; }
    public string? RouteName { get; set; }
    public string? Keywords { get; set; }
    public int CategoryId { get; set; }
    public string? ParentCategoryName { get; set; }
    [JsonIgnore]
    public virtual Category? Category { get; set; }
    [JsonIgnore]
    public virtual List<Product>? Products { get; set; }
}