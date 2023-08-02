using System;
using System.Collections.Generic;

namespace DoMains.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Avarta { get; set; }

    public DateTime? Birthday { get; set; }

    public int? Sex { get; set; }

    public string Mobile { get; set; } = null!;

    public string? Email { get; set; }

    public string? Company { get; set; }

    public string? Roles { get; set; }

    public bool? IsAdminUser { get; set; }

    public bool? IsLocked { get; set; }

    public string? Session { get; set; }

    public string? SessionId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
