using AutoMapper;
using Models.DataModels;
using Models.ViewModels;

namespace Mvc.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            //CreateMap<ApplicationUser, ApiUser>().ReverseMap();
            //CreateMap<ApplicationUser, ApiRegister>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<HomeContact, HomeContactVM>().ReverseMap();
        }
    }
}