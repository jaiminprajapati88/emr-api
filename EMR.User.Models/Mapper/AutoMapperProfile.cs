using AutoMapper;
using EMR.Data.Context;
using EMR.Data.Model.Config;
using EMR.Data.Model.Organization.Request;
using EMR.Data.Model.Patient;
using EMR.Data.Model.Patient.Request;
using EMR.Data.Model.User;
using EMR.Data.Model.User.Request;

namespace EMR.Data.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppPreference, AppPreferenceModel>();
            CreateMap<City, CityModel>();
            CreateMap<State, StateModel>();
            CreateMap<Country, CountryModel>();
            CreateMap<Message, MessageModel>();
            CreateMap<TypeGroup, TypeGroupModel>();
            CreateMap<TypeRef, TypeRefModel>();

            CreateMap<UserDetail, UserDetailModel>();
            CreateMap<SaveUserRequestModel, UserDetail>();

            CreateMap<SaveOrganizationRequestModel, OrganizationDetail>();

            CreateMap<SavePatientRequestModel, PatientDetail>();
            CreateMap<PatientDetail, PatientDetailModel>();
        }
    }
}
