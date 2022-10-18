using AutoMapper;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models.LearningMaterialDtos;
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
            CreateMap<LearningMaterial, LearningMaterialDto>();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<Subject,ShortSubjectDto>();
            CreateMap<CreateTestDto, Test>();
            CreateMap<CreateLearningMaterialDto, LearningMaterial>();
        }
    }
}
