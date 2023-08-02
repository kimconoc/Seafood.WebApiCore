﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class UserAdmin : BaseEntity
    {
        public static ClaimsIdentity Identity { get; internal set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string DisplayName { get; set; }
        public string Avarta { get; set; }
        public DateTime? Birthday { get; set; }
        public int Sex { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Roles { get; set; }
        public bool IsAdminUser { get; set; }
        public bool IsLocked { get; set; } = false;
        public string Session { get; set; }
        public string SessionId { get; set; }
    }
}
