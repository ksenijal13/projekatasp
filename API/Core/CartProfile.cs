using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartDto, Cart>();
            CreateMap<AddInCartDto, Cart>();
            CreateMap<Cart, YourCartDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(x => x.Perfume.Brand.Name))
                .ForMember(dest => dest.FragranceName, opt => opt.MapFrom(x => x.Perfume.Fragrance))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(x => x.Perfume.Image))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Perfume.Price * x.Quantity));
        }
    }
}
