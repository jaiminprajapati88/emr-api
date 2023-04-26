using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismDataLayer.DataModels
{
    public class ReferenceModel
    {
        public List<StateModel> StateModels { get; set; } = new List<StateModel>();
        public List<TypeGroupModel> typeGroupModels { get; set; } = new List<TypeGroupModel>();
        public List<MessageModel> messageModels { get; set; } = new List<MessageModel>();
        public List<AppPreferenceModel> appPreferenceModels { get; set; } = new List<AppPreferenceModel>();
    }
}
