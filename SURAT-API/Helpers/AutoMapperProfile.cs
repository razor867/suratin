using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using SURAT_API.Models;
using SURAT_API.ViewModels;

namespace SURAT_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        private readonly IConfiguration? _config;
        public AutoMapperProfile(IConfiguration config)
        {
            this._config = config;

            CreateMap<surat_masuk, SuratMasukDto>()
                .ForMember(des => des.IdSuratMasuk, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Regarding, opt => opt.MapFrom(src => src.Regarding))
                .ForMember(des => des.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(des => des.ToPerson, opt => opt.MapFrom(src => src.To_person))
                .ForMember(des => des.FromPerson, opt => opt.MapFrom(src => src.From_person))
                .ForMember(des => des.Message, opt => opt.MapFrom(src => src.Message));
        }
    }
}