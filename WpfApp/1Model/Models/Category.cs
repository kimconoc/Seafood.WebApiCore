using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model.Models
{
    public partial class Category : BasePropertyChanged
    {
        private Guid _id;
        public Guid Id { get => _id; set { _id = value; OnPropertyChanged(); } }

        private string? _name;
        public string? Name { get => _name; set { _name = value; OnPropertyChanged(); } }

        private string? _description;
        public string? Description { get => _description; set { _description = value; OnPropertyChanged(); } }

        private string? _note;
        public string? Note { get => _note; set { _note = value; OnPropertyChanged(); } }

        private string? _code;
        public string? Code { get => _code; set { _code = value; OnPropertyChanged(); } }

        private string? _icon;
        public string? Icon { get => _icon; set { _icon = value; OnPropertyChanged(); } }

        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
