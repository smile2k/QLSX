using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Module.Products.Models
{
    public class EditProductData
    {
        public BigInteger ID { get; set; }
        public int Step { get; set; }
        public string StepName { get; set; }
        public DateTime ExpectDay { get; set; }
        public DateTime ActualDay { get; set; }
        public string Status { get; set; }

    }

    public enum ProductionStatus
    {
        Done,
        Inprogress,
        None,
        Missing
    }
}
