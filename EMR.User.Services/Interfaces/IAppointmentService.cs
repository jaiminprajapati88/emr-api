using EMR.Data.Context;
using EMR.Data.Model.Appointment.Request;
using EMR.Data.Model.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentModel>> GetAll(AppointmentRequestModel request);

        Task<bool> Save(SaveAppointmentModel appointment);

        Task<IEnumerable<AppointmentServiceModel>> GetAllService(AppointmentServiceRequestModel request);

        Task<bool> SaveService(SaveAppointmentServiceModel appointmentService);
    }
}
