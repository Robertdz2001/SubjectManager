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
                    PhoneNumber="65485493543",
                    Subjects = new List<Subject>()
                    {
                       new Subject()
                       {
                           Name="TestSubject",
                           ShortName="TS",
                           PlatformUrl="http://testPlatform1.com",
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
                           },
                           LearningMaterials = new List<LearningMaterial>()
                           {
                               new LearningMaterial()
                               {
                                   Name="test1Material",
                                   Source="http://test1.com"
                               },
                               new LearningMaterial()
                               {
                                   Name="test2Material",
                                   Source="http://test2.com"
                               }
                           }
                       }

                    }
                },


                new User()
                {
                    Email = "test2@test.com",
                    FirstName="John",
                    LastName="Bill",
                    PhoneNumber="48549304835",
                    Subjects = new List<Subject>()
                    {
                       new Subject()
                       {
                           Name="Informatics",
                           ShortName="IT",
                           PlatformUrl="http://testPlatform2.com",
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
                           },
                            LearningMaterials = new List<LearningMaterial>()
                           {
                               new LearningMaterial()
                               {
                                   Name="test3Material",
                                   Source="http://test3.com"
                               },
                               new LearningMaterial()
                               {
                                   Name="test4Material",
                                   Source="http://test4.com"
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
