using System;
using System.Collections.Generic;

namespace SeafoodApi.Models;

public partial class Voucher
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int TypeVoucher { get; set; }

    public int ReductionAmount { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? ConditionsApply { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
