using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extentions;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(
                    destination => destination.Age,
                    options => options.MapFrom(source => source.DateOfBirth.CalculateAge())
                )
                .ForMember(
                    destination => destination.PhotoUrl,
                    options => options
                         .MapFrom(source => source.Photos.FirstOrDefault(x => x.IsMain)!.Url)
                );
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
        }
    }
}