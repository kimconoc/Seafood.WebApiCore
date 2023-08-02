using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoMains.DTO
{
    public class CategorysDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? Icon { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
