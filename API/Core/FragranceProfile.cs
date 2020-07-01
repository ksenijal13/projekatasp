using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core
{
    public class FragranceProfile : Profile
    {
        public FragranceProfile()
        {
            CreateMap<FragranceType, FragranceTypeDto>();
        }
    }
}
