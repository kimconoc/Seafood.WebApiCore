using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class Address
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string CodeRegion { get; set; } = null!;

    public string CodeDistrict { get; set; } = null!;

    public string CodeWard { get; set; } = null!;

    public int TypeAddress { get; set; }

    public int TypeAddressDetail { get; set; }

    public bool IsAddressMain { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
