namespace SubjectManagerAPI.Models.SubjectDtos
{
    public class ShortSubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? RoomNumber { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public string? Time { get; set; }
        public string? PlatformUrl { get; set; }
    }
}
