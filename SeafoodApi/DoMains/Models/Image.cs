using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class Image
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? ShopSeefoodId { get; set; }

    public Guid? MoreImgId { get; set; }

    public string? UrlPath { get; set; }

    public string? Base64Str { get; set; }

    public bool IsImageMain { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
