using System.Transactions;

namespace SubjectManagerAPI.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int ?RoomNumber { get; set; }
        public DayOfWeek ?DayOfWeek { get; set; }
        public string ?Time { get; set; }
        public string ?PlatformUrl { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public List<Test> Tests { get; set; }
        public List<LearningMaterial> LearningMaterials { get; set; }
    }
}
