using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismDataLayer.DataModels
{
    public class MessageModel : BaseModel
    {
        public string MessageId { get; set; }
        public string MessageDesc { get; set; }
        public int MessageTypeCode { get; set; }
    }
}
