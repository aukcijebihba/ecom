using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Message
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int SenderId { get; set; }
    public int RecipientId { get; set; }
    [StringLength(1000, MinimumLength = 1)]
    public required string Text { get; set; }
}