using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class SeafoodPromotion
{
    public Guid Id { get; set; }

    public string? ShopCode { get; set; }

    public string? Content { get; set; }

    public string? Note { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
