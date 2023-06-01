using AutoMapper;
using EMR.Common.Extension;
using EMR.Data.Context;
using EMR.Data.Model.Appointment;
using EMR.Data.Model.Appointment.Request;
using EMR.Services.Interfaces;
using EMR.UnitOfWork.Interfaces;

namespace EMR.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        #region Properties

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        #endregion Properties

        #region Constuctor

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constuctor

        #region Service Methods

        public async Task<IEnumerable<AppointmentModel>> GetAll(AppointmentRequestModel request)
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.AppointmentRepository.GetAll(request);
            }
        }

        public async Task<IEnumerable<AppointmentServiceModel>> GetAllService(AppointmentServiceRequestModel request)
        {
            using (var context = _unitOfWork.Create())
            {
                var services = await context.Repositories.AppointmentRepository.GetAllService(request);
                return _mapper.Map<IEnumerable<AppointmentServiceModel>>(services);
            }
        }

        public async Task<bool> Save(SaveAppointmentModel appointment)
        {
            using (var context = _unitOfWork.Create())
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointment);

                if(appointment.AppointmentId > 0)
                {
                    appointmentEntity =  context.Repositories.AppointmentRepository.GetDetail(appointment.AppointmentId.Value).Result;
                    appointment.CopyProperties(appointmentEntity);
                    appointmentEntity.RowUpdateStamp = DateTime.Now;
                    appointmentEntity.RowUpdateUserId = "SYSTEM";
                }
                                
                var result = await context.Repositories.AppointmentRepository.Save(appointmentEntity);
                await context.CommitTransaction();
                return result;
            }
        }

        public async Task<bool> SaveService(SaveAppointmentServiceModel appointmentService)
        {
            using (var context = _unitOfWork.Create())
            {
                var serviceEntity = _mapper.Map<EMR.Data.Context.AppointmentService>(appointmentService);

                if (appointmentService.AppointmentServiceId > 0)
                {
                    serviceEntity = context.Repositories.AppointmentRepository.GetServiceDetail(appointmentService.AppointmentServiceId.Value).Result;
                    appointmentService.CopyProperties(serviceEntity);
                    serviceEntity.RowUpdateStamp = DateTime.Now;
                    serviceEntity.RowUpdateUserId = "SYSTEM";
                }

                var result = await context.Repositories.AppointmentRepository.SaveService(serviceEntity);
                await context.CommitTransaction();

                return result;
            }

        }

        #endregion Service Methods

    }
}
