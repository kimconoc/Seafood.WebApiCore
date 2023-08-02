using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class ProdPromotion
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? Content { get; set; }

    public bool? PromotionMain { get; set; }

    public string? Note { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
