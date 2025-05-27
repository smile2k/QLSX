using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Based.Common.Models
{
    public class FactoryProduct
    {
        public int Id { get; set; }
        [Column("factory_id")]
        public int FactoryId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("process_id")]
        public int ProcessId { get; set; }
        [Column("expect_quantity")]
        public ulong ExpectQuantity { get; set; }
        [Column("actual_quantity")]
        public ulong ActualQuantity { get; set; }
        public string? Status { get; set; }
        public string? Comment { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

}
