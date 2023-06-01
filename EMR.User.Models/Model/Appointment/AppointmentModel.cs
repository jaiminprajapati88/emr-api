namespace EMR.Data.Model.Appointment
{
    public class AppointmentModel
    {
        public long AppointmentId { get; set; }

        public Guid OrganizationDetailId { get; set; }

        public Guid UserDetailId { get; set; }

        public Guid PatientDetailId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string CellNo { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string ServiceName { get; set; }

        public decimal? ServiceQty { get; set; }

        public decimal? ServiceDiscount { get; set; }

        public decimal? Payment { get; set; }

        public string Status { get; set; }

        public string? Remarks { get; set; }

        public string? Notes { get; set; }
    }
}
