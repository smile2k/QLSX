using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Based.Common.Models
{
    public class FactoryProductStep
    {
        public int Id { get; set; }
        [Column("factory_product_id")]
        public int FactoryProductId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("step_id")]
        public int? StepId { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("expect_date")]
        public DateTime ExpectDate { get; set; }
        [Column("actual_date")]
        public DateTime ActualDate { get; set; }
        public string Status { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

}
