using AutoMapper;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models;
using SubjectManagerAPI.Models.SubjectDtos;
using SubjectManagerAPI.Models.TestDtos;

namespace SubjectManagerAPI
{
    public class SubjectManagerMappingProfile : Profile
    {
        public SubjectManagerMappingProfile()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<Test, TestDto>();
            CreateMap<Test, TestWithSubjectDto>();
            CreateMap<LearningMaterial, LearningMaterialDto>();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<Subject,ShortSubjectDto>();
            CreateMap<CreateTestDto, Test>();
        }
    }
}
