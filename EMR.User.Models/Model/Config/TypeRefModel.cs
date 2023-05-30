namespace EMR.Data.Model.Config
{
    public class TypeRefModel
    {
        public int TypeCode { get; set; }

        public int TypeGroupCode { get; set; }

        public string TypeDesc { get; set; } = null!;

        public string? TypeFullDesc { get; set; }

        public int? Sequence { get; set; }

        public bool IsActive { get; set; }
    }
}
