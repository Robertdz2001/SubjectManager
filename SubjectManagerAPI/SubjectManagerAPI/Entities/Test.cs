namespace SubjectManagerAPI.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public DateTime? Date { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject ?Subject { get; set; }
    }

}
