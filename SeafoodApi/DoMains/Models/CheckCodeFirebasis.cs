using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class CheckCodeFirebasis
{
    public Guid Id { get; set; }

    public string Mobile { get; set; } = null!;

    public DateTime TimeSend { get; set; }

    public int NumberOfSend { get; set; }

    public string? LatestCode { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
