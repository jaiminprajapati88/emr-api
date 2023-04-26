using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismDataLayer.DataModels
{
    public class BaseModel
    {
        public string RowAddUserId { get; set; }
        public DateTime RowAddStamp { get; set; } = DateTime.Now;
        public string RowUpdateUserId { get; set; }
        public DateTime RowUpdateStamp { get; set; } = DateTime.Now;
        public Boolean IsActive { get; set; } = true;
    }
}
