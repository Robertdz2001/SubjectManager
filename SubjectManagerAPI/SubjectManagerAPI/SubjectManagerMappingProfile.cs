﻿using AutoMapper;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models;
using SubjectManagerAPI.Models.SubjectDtos;

namespace SubjectManagerAPI
{
    public class SubjectManagerMappingProfile : Profile
    {
        public SubjectManagerMappingProfile()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<Test, TestDto>();
            CreateMap<LearningMaterial, LearningMaterialDto>();
            CreateMap<CreateSubjectDto, Subject>();
        }
    }
}