using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.Model
{
    public class BaseModel
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<DateTime> LastModifiedTime { get; set; }
        public byte[] TimeStatus { get; set; }
        public short RowStatus { get; set; }
    }
}
