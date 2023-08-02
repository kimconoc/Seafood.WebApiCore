using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class SessionAuthorizeAdmin
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string? IpRequest { get; set; }

    public string? Session { get; set; }

    public string? SessionId { get; set; }

    public DateTime TimeLogin { get; set; }

    public DateTime? TimeLogout { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
