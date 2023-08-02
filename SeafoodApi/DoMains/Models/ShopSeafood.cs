using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class ShopSeafood
{
    public Guid Id { get; set; }

    public string CodeRegion { get; set; } = null!;

    public string CodeDistrict { get; set; } = null!;

    public string CodeWard { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int TypeAddress { get; set; }

    public string Mobile { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
