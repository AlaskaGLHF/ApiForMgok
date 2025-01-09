using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiForMgok.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Comment { get; set; }

    public bool Status { get; set; }

    public int RoleId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual Role Role { get; set; } = null!;
}
