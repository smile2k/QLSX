using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Module.Factory.Models
{
    public class FactoryData
    {
        public BigInteger ID { get; set; }
        public string FactoryName { get; set; }
        public int CompletedQuantity { get; set; }
        public int InprogressQuantity { get; set; }

    }

}
