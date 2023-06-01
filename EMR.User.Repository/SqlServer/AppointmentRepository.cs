using EMR.Data.Context;
using EMR.Data.Model.Appointment;
using EMR.Data.Model.Appointment.Request;
using EMR.Repository.Core;
using EMR.Repository.Extension;
using EMR.Repository.Interfaces;

namespace EMR.Repository.SqlServer
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        #region Constuctor

        public AppointmentRepository(EmrContext context) : base(context) { }

        #endregion Constuctor

        #region Repository Methods

        public async Task<IEnumerable<AppointmentModel>> GetAll(AppointmentRequestModel request)
        {
            var query = from appointment in _context.Appointments
                        join service in _context.AppointmentServices on appointment.ServiceId equals service.AppointmentServiceId
                        join patient in _context.PatientDetails on appointment.PatientDetailId equals patient.PatientDetailId
                        join status in _context.TypeRefs on appointment.StatusId equals status.TypeCode
                        join gender in _context.TypeRefs on patient.GenderId equals gender.TypeCode
                        where appointment.OrganizationDetailId == request.OrganizationDetailId && appointment.UserDetailId == request.UserDetailId && appointment.AppointmentDateTime.Date == request.AppointmentDate.Date
                        select new AppointmentModel()
                        {
                            AppointmentId = appointment.AppointmentId,
                            AppointmentDateTime = appointment.AppointmentDateTime,
                            CellNo = patient.CellNo,
                            DateOfBirth = patient.DateOfBirth,
                            FirstName = patient.FirstName,
                            LastName = patient.LastName,
                            Gender = gender.TypeDesc,
                            Notes = appointment.Notes,
                            OrganizationDetailId = appointment.OrganizationDetailId,
                            PatientDetailId = appointment.PatientDetailId,
                            Payment = appointment.Payment,
                            Remarks = appointment.Remarks,
                            ServiceDiscount = appointment.ServiceDiscount,
                            ServiceName = service.ServiceName,
                            ServiceQty = appointment.ServiceQty,
                            Status = status.TypeDesc,
                            UserDetailId = appointment.UserDetailId
                        };

            return await query.ToListAsyncSafe();
        }

        public async Task<Appointment> GetDetail(long appointmentId)
        {
            return await base.GetById<Appointment>(appointmentId);
        }

        public async Task<bool> Save(Appointment appointment)
        {
            int result = 0;

            if (appointment.AppointmentId > 0)
            {
                base.Update<Appointment>(appointment);
            }
            else
            {
                await base.Add<Appointment>(appointment);
            }

            result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<IEnumerable<AppointmentService>> GetAllService(AppointmentServiceRequestModel request)
        {
            return await base.GetAll<AppointmentService>(service => service.OrganizationDetailId == request.OrganizationDetailId && service.UserDetailId == request.UserDetailId);
        }

        public async Task<AppointmentService> GetServiceDetail(int appointmentServiceId)
        {
            return await base.GetById<AppointmentService>(appointmentServiceId);
        }

        public async Task<bool> SaveService(AppointmentService appointmentService)
        {
            int result = 0;

            if (appointmentService.AppointmentServiceId > 0)
            {
                base.Update<AppointmentService>(appointmentService);
            }
            else
            {
                await base.Add<AppointmentService>(appointmentService);
            }

            result = _context.SaveChanges();
            return result > 0;
        }

        #endregion Repository Methods
    }
}
