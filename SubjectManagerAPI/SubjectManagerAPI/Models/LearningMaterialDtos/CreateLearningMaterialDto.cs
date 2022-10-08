using System.ComponentModel.DataAnnotations;

namespace SubjectManagerAPI.Models.LearningMaterialDtos
{
    public class CreateLearningMaterialDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Source { get; set; }
    }
}
