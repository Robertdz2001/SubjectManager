namespace SubjectManagerAPI.Entities
{
    public class LearningMaterial
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Source { get; set; }
        public int SubjectId {get; set;}
        public virtual Subject ?Subject { get; set; }
    }
}
