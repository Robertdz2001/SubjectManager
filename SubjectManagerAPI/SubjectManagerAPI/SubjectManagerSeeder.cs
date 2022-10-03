using SubjectManagerAPI.Entities;

namespace SubjectManagerAPI
{
    public class SubjectManagerSeeder
    {
        private readonly SubjectManagerDbContext _dbContext;
        public SubjectManagerSeeder(SubjectManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }



        }
        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Email = "test1@test.com",
                    FirstName="TestFirstName",
                    Subjects = new List<Subject>()
                    {
                       new Subject()
                       {
                           Name="TestSubject",
                           ShortName="TS",
                           Tests = new List<Test>()
                           {
                            new Test()
                            {
                            Name = "TestTest1"

                            },

                             new Test()
                             {
                            Name = "TestTest2",

                             }
                           }
                       }

                    }
                },


                new User()
                {
                    Email = "test2@test.com",
                    FirstName="John",
                    Subjects = new List<Subject>()
                    {
                       new Subject()
                       {
                           Name="Informatics",
                           ShortName="IT",
                           Tests = new List<Test>()
                           {
                            new Test()
                            {
                            Name = "EF"

                            },

                             new Test()
                             {
                            Name = "AutoMapper",

                             }
                           }
                       }

                    }
                }



            };
            return users;
        }
    }
}
