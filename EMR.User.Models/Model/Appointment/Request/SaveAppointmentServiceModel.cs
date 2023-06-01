using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Model.Appointment.Request
{
    public class SaveAppointmentServiceModel
    {
        public int? AppointmentServiceId { get; set; }

        [Required]
        public Guid OrganizationDetailId { get; set; }

        [Required]
        public Guid UserDetailId { get; set; }

        [Required]
        public string ServiceName { get; set; } = null!;

        [Required]
        public decimal ServicePrice { get; set; }

        public decimal? ServiceTax { get; set; }

        public string? ServiceCode { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
