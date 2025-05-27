using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Based.Common.Models
{
    public class Log
    {
        public int Id { get; set; }
        [Column("table_name")]
        public string TableName { get; set; }
        [Column("table_id")]
        public int TableId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

}
