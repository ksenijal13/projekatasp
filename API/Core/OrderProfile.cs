using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(x => x.OrderItems.Select(i =>
                new OrderItem
                {
                    PerfumeId = i.PerfumeId,
                    Quantity = i.Quantity,
                    Price = i.Price
                }
                )))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(x => x.OrderItems.Sum(x => x.Price)));
        }
    }
}
