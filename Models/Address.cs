using System;
using System.Collections.Generic;

namespace ApiForMgok.Models;

public partial class Address
{
    public int Id { get; set; }

    public string AddressName { get; set; } = null!;

    public bool? Status { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
