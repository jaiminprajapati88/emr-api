using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismDataLayer.DataModels.Config
{
    public class AppPreferenceModel : BaseModel
    {
        public string PreferenceId { get; set; }
        public string PreferenceValue { get; set; }
        public string PreferenceDesc { get; set; }
        public bool IsConfig { get; set; }
    }
}
