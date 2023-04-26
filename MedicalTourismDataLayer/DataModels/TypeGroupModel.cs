using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismDataLayer.DataModels
{
    public class TypeGroupModel : BaseModel
    {
        public int TypeGroupCode { get; set; }
        public string TypeGroupDesc { get; set; }
        public List<TypeRef> typeRef { get; set; }
    }

    public class TypeRef : BaseModel
    {
        public int TypeCode { get; set; }
        public int TypeGroupCode { get; set; }
        public string TypeDesc { get; set; }
        public string TypeFullDesc { get; set; }
        public int Sequence { get; set; }
    }
}
