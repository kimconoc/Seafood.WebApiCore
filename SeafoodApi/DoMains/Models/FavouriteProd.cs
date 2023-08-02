using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class FavouriteProd
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? IpRequest { get; set; }

    public Guid ProductId { get; set; }

    public Guid? ProdBasketId { get; set; }

    public string? ClassName { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
