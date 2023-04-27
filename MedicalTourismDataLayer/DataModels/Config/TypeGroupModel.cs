using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismDataLayer.DataModels.Config
{
    public class TypeGroupModel : BaseModel
    {
        public int TypeGroupCode { get; set; }
        public string TypeGroupDesc { get; set; }
    }
}
