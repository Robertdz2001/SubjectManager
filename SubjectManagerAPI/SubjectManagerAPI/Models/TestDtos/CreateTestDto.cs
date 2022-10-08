using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SubjectManagerAPI.Models.TestDtos
{
    public class CreateTestDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
