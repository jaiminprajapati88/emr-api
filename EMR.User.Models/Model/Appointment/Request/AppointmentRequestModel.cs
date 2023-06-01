namespace EMR.Data.Model.Appointment.Request
{
    public class AppointmentRequestModel
    {
        public Guid OrganizationDetailId { get; set; }
        public Guid UserDetailId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
