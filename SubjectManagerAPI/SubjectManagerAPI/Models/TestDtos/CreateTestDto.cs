using System.Runtime.CompilerServices;

namespace SubjectManagerAPI.Models.TestDtos
{
    public class CreateTestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
