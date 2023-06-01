using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Model.Appointment.Request
{
    public class SaveAppointmentModel
    {
        public long? AppointmentId { get; set; }
        
        [Required]
        public Guid OrganizationDetailId { get; set; }

        [Required]
        public Guid UserDetailId { get; set; }

        [Required]
        public Guid PatientDetailId { get; set; }

        [Required]
        public DateTime AppointmentDateTime { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public decimal? ServiceQty { get; set; }

        public decimal? ServiceDiscount { get; set; }

        public decimal? Payment { get; set; }

        [Required]
        public int StatusId { get; set; }

        public string? Remarks { get; set; }

        public string? Notes { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
