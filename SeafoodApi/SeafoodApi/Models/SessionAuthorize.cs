using System;
using System.Collections.Generic;

namespace SeafoodApi.Models;

public partial class SessionAuthorize
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string? IpRequest { get; set; }

    public string Session { get; set; } = null!;

    public string SessionId { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
