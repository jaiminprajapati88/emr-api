namespace MedicalTourismDataLayer.DataModels.Config
{
    public class TypeRefModel : BaseModel
    {
        public int TypeCode { get; set; }
        public int TypeGroupCode { get; set; }
        public string TypeDesc { get; set; }
        public string TypeFullDesc { get; set; }
        public int Sequence { get; set; }
    }
}
