using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class ProdProcessing
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Note { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
