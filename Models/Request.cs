using System;
using System.Collections.Generic;

namespace ApiForMgok.Models;

public partial class Request
{
    public int Id { get; set; }

    public int ChatId { get; set; }

    public int AddressId { get; set; }

    public string Cabinet { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Photo { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public int? EmployeeId { get; set; }

    public int? StatusId { get; set; }

    public string? EmployeeComment { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual RequestStatus? Status { get; set; }
}
