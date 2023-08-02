using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class Region
{
    public Guid Id { get; set; }

    public string? NameRegion { get; set; }

    public string? CodeRegion { get; set; }

    public string? NameDistrict { get; set; }

    public string? CodeDistrict { get; set; }

    public string? NameWard { get; set; }

    public string? CodeWard { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
