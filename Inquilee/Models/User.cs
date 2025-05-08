using System.ComponentModel.DataAnnotations;

namespace Inquilee.Models;

public class User
{
    [Key] public string Id { get; set; }
}