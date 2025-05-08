using System.ComponentModel.DataAnnotations;
using Inquilee.Models.Enums;

namespace Inquilee.Models;

public class Residence
{
    [Key] public string Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Name { get; set; }
    public ResidenceType Type { get; set; }
    public Tenant Tenant { get; set; }
}