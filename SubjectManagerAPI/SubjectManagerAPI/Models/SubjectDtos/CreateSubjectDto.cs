using System.ComponentModel.DataAnnotations;

namespace SubjectManagerAPI.Models.SubjectDtos
{
    public class CreateSubjectDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string ShortName { get; set; }
        public int? RoomNumber { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }

        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")]
        public string? Time { get; set; }
        public string? PlatformUrl { get; set; }
    }
}
