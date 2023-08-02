using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public Guid ProdProcessingId { get; set; }

    public Guid AddressId { get; set; }

    public int TypeAddress { get; set; }

    public string Code { get; set; } = null!;

    public int Status { get; set; }

    public string? CodeVoucher { get; set; }

    public int? TypeVoucher { get; set; }

    public int Quantity { get; set; }

    public int TotalPrice { get; set; }

    public DateTime TimeOrder { get; set; }

    public DateTime? StartDeliveryTime { get; set; }

    public DateTime? EstimateDeliveryTime { get; set; }

    public DateTime? SuccessfulDeliveryTime { get; set; }

    public DateTime? CancellationTime { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
