using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<InsertBrandDto, Brand>();
            CreateMap<Brand, ReadBrandPerfumesDto>()
                .ForMember(dest => dest.Perfumes, opt => opt.MapFrom(b => b.Perfumes.Select(x => new PerfumeDto
                {
                    Id = x.Id,
                    Fragrance = x.Fragrance,
                    BrandId = x.BrandId,
                   // Brand = x.Brand.ToString(),
                    GenderId = x.GenderId,
                    //Gender = x.Gender.ToString(),
                    FragranceTypeId = x.FragranceTypeId,
                  //  FragranceType = x.FragranceType.ToString(),
                    Price = x.Price,
                    Discount = x.Discount,
                    NumberOfAvailable = x.NumberOfAvailable,
                    Image = x.Image,
                    PerfumeScentNotes = x.PerfumeScentNotes.Select(p => new DefineScentNotes
                    {
                        ScentNoteId = p.ScentNote.Id,
                        ScentNote = p.ScentNote.Name
                    })

                })));
        }
    }
}
