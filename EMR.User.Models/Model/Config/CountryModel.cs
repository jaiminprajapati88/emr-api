namespace EMR.Data.Model.Config
{
    public class CountryModel
    {
        public short CountryId { get; set; }

        public string CountryName { get; set; } = null!;

        public string CountryNickName { get; set; } = null!;

        public string Iso { get; set; } = null!;

        public string? Iso3 { get; set; }

        public int PhoneCode { get; set; }

        public bool IsActive { get; set; }
    }
}
