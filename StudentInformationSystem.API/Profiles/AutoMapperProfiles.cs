﻿using AutoMapper;
using DataModels = StudentInformationSystem.API.DataModels;
using StudentInformationSystem.API.DomainModels;

namespace StudentInformationSystem.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>().ReverseMap();
            CreateMap<DataModels.Gender, Gender>().ReverseMap();
            CreateMap<DataModels.Address, Address>().ReverseMap();
        }
    }
}