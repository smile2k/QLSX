using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Based.Common.Models
{
    public class ProcessStep
    {
        public int Id { get; set; }
        [Column("process_id")]
        public int ProcessId { get; set; }
        [Column("step_id")]
        public int StepId { get; set; }
        public int Position { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

}
