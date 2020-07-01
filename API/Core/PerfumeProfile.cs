using Application.DataTransfer;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core
{
    public class PerfumeProfile : Profile
    {
        public PerfumeProfile()
        {
            CreateMap<CreatePerfumeDto, Perfume>()
                .ForMember(dest => dest.PerfumeScentNotes,
                dto => dto.MapFrom(x => x.PerfumeScentNotes.Select(psn => new PerfumeScentNote
                {
                    ScentNoteId = psn
                })));
           
            CreateMap<Perfume, PerfumeDto>()
                .ForMember(dest => dest.PerfumeScentNotes, opt => opt.MapFrom(x => x.PerfumeScentNotes.Select(psn => new DefineScentNotes
                {
                    ScentNoteId = psn.ScentNote.Id,
                    ScentNote = psn.ScentNote.Name
                }).ToList()))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(x => x.Brand.Name))
                 .ForMember(dest => dest.FragranceType, opt => opt.MapFrom(x => x.FragranceType.Name))
                  .ForMember(dest => dest.Gender, opt => opt.MapFrom(x => x.Gender.Name));
        }
    }
}
