namespace EMR.Data.Model.Config
{
    public class TypeGroupModel
    {
        public int TypeGroupCode { get; set; }

        public string TypeGroupDesc { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
