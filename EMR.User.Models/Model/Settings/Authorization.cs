namespace EMR.Data.Model.Settings
{
    public class Authorization
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Expiration { get; set; }
    }
}
