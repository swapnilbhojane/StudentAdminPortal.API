﻿using DataModels =  StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DomainModels;
using AutoMapper;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
            public AutoMapperProfiles ()
            {
                CreateMap<DataModels.Student, Student>()
                    .ReverseMap();

                CreateMap<DataModels.Gender, Gender>()
                    .ReverseMap();

                CreateMap<DataModels.Address, Address>()
                    .ReverseMap();
            }
        
    }
} 
