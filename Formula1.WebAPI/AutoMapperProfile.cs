using AutoMapper;
using Formula1.Client.DTO.Read;
using Formula1.Client.Requests.Create;
using Formula1.Client.Requests.Update;
using Formula1.Domain.Models;

namespace Formula1.WebAPI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.F1Team, Domain.F1Team>();
            this.CreateMap<DataAccess.Entities.Rider, Domain.Rider>();
            this.CreateMap<Domain.F1Team, F1TeamDTO>();
            this.CreateMap<Domain.Rider, RiderDTO>();
            
            this.CreateMap<F1TeamCreateDTO, F1TeamUpdateModel>();
            this.CreateMap<F1TeamUpdateDTO, F1TeamUpdateModel>();
            this.CreateMap<F1TeamUpdateModel, DataAccess.Entities.F1Team>();

            this.CreateMap<RiderCreateDTO, RiderUpdateModel>();
            this.CreateMap<RiderUpdateDTO, RiderUpdateModel>();
            this.CreateMap<RiderUpdateModel, DataAccess.Entities.Rider>();
        }
    }
}