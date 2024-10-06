using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using Shared.UserDtos;

namespace GeorgianFoodReviewAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Country, CountryDto>();

            CreateMap<Reviewer, ReviewerDto>();
            
            CreateMap<Food, FoodDto>();

            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.FoodName, opt => opt.MapFrom(src => src.Food.Name));

            CreateMap<CountryForCreationDto, Country>();

            CreateMap<CategoryToCreateDto, Category>();

            CreateMap<ReviewerForCreationDto, Reviewer>();

            CreateMap<FoodForCreationDto, Food>();

            CreateMap<ReviewForCreationDto, Review>();

            CreateMap<ReviewerForUpdateDto, Reviewer>().ReverseMap();

            CreateMap<CountryForUpdateDto, Country>();

            CreateMap<FoodForUpdateDto, Food>();

            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<ReviewForUpdateDto, Review>().ReverseMap();

               
                
               

        }
    }
}
