using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Based.Common.Models
{
    public class Product
    {
        public int Id { get; set; }
        public uint Category_Id { get; set; }

        public string Sku { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        // Navigation Property
        //public Category Category { get; set; }
    }
}
