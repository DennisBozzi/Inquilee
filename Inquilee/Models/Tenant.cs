using System.ComponentModel.DataAnnotations;

namespace Inquilee.Models;

public class Tenant
{
    [Key] public string Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Name { get; set; }
    public string Cpf { get; set; }
    public bool IsResponsible { get; set; }
    public Tenant? ResponsibleTenant { get; set; }
}