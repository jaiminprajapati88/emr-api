namespace EMR.Data.Model.Config
{
    public class CityModel
    {
        public int CityId { get; set; }

        public string CityName { get; set; } = null!;

        public string StateCode { get; set; } = null!;

        public string CountryCode { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
