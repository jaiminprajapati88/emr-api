namespace EMR.Data.Model.Config
{
    public class AppPreferenceModel
    {
        public string PreferenceId { get; set; } = null!;

        public string PreferenceValue { get; set; } = null!;

        public string PreferenceDesc { get; set; } = null!;

        public bool? IsActive { get; set; }

        public bool? IsConfig { get; set; }
    }
}
