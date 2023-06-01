namespace EMR.Data.Model.Appointment
{
    public class AppointmentServiceModel
    {
        public int AppointmentServiceId { get; set; }

        public Guid OrganizationDetailId { get; set; }

        public Guid UserDetailId { get; set; }

        public string ServiceName { get; set; } = null!;

        public decimal ServicePrice { get; set; }

        public decimal? ServiceTax { get; set; }

        public string? ServiceCode { get; set; }
    }
}
