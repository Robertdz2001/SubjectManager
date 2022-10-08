using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models.LearningMaterialDtos;
using SubjectManagerAPI.Models.TestDtos;

namespace SubjectManagerAPI.Models.SubjectDtos
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? RoomNumber { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public string? Time { get; set; }
        public string? PlatformUrl { get; set; }
        public List<TestDto> Tests { get; set; }
        public List<LearningMaterialDto> LearningMaterials { get; set; }
    }
}
