using SubjectManagerAPI.Models.SubjectDtos;

namespace SubjectManagerAPI.Models.TestDtos
{
    public class TestWithSubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public ShortSubjectDto? Subject { get; set; }
    }
}
