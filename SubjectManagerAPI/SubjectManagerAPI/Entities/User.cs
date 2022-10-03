namespace SubjectManagerAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string PasswordHash { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
