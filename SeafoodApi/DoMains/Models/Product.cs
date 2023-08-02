using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string CategoryCode { get; set; } = null!;

    public string ShopCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double? ReviewProd { get; set; }

    public int Price { get; set; }

    public int PriceSale { get; set; }

    public double? Amount { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
