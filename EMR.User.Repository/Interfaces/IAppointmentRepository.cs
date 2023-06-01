using EMR.Data.Context;
using EMR.Data.Model.Appointment;
using EMR.Data.Model.Appointment.Request;

namespace EMR.Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<AppointmentModel>> GetAll(AppointmentRequestModel request);
        Task<Appointment> GetDetail(long appointmentId);

        Task<bool> Save(Appointment appointment);

        Task<IEnumerable<AppointmentService>> GetAllService(AppointmentServiceRequestModel request);

        Task<AppointmentService> GetServiceDetail(int appointmentServiceId);

        Task<bool> SaveService(AppointmentService appointmentService);
    }
}
