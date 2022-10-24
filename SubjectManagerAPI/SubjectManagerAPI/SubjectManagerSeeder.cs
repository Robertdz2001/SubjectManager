using Microsoft.EntityFrameworkCore;
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
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();

                if (pendingMigrations!=null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
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
                    Email = "bill2315@gmail.com",
                    FirstName="Bill",
                    LastName="Smith",
                    PhoneNumber="65485493543",
                    PasswordHash="AQAAAAEAACcQAAAAEJgxNorzKzcpDi90JSCKGbqloXVb31ts+zm3VD+ajhl0Y4I011sLS2fUNEYMhJqt8g==", //password  = 123456
                    Subjects = new List<Subject>()
                    {
                       new Subject()
                       {
                           Name="Mathematics",
                           ShortName="Math",
                           RoomNumber=305,
                           DayOfWeek=DayOfWeek.Monday,
                           Time="12:00",
                           PlatformUrl="http://mathPlatform1.com",
                           Tests = new List<Test>()
                           {
                            new Test()
                            {
                            Name = "Integrals",
                            Description = "Solving differential equations",
                            Date = new DateTime(2022,11,22)
                            },

                             new Test()
                             {
                            Name = "Derivatives",
                            Description = "Determining the extreme of a function",
                            Date = new DateTime(2022,12,25)
                             }
                           },
                           LearningMaterials = new List<LearningMaterial>()
                           {
                               new LearningMaterial()
                               {
                                   Name="Discrete Mathematics with Applications",
                                   Source="https://tiny.pl/w7skk"
                               },
                               new LearningMaterial()
                               {
                                   Name="Math platform",
                                   Source="http://4math.ms.polsl.pl/"
                               }
                           }
                       }

                    }
                },


                new User()
                {
                    Email = "john328@gmail.com",
                    FirstName="John",
                    LastName="Williams",
                    PhoneNumber="48549304835",
                    PasswordHash="AQAAAAEAACcQAAAAEJgxNorzKzcpDi90JSCKGbqloXVb31ts+zm3VD+ajhl0Y4I011sLS2fUNEYMhJqt8g==", //password  = 123456
                    Subjects = new List<Subject>()
                    {
                       new Subject()
                       {
                           Name="Informatics",
                           ShortName="IT",
                           PlatformUrl="http://ITPlatform.com",
                           RoomNumber=124,
                           DayOfWeek=DayOfWeek.Wednesday,
                           Time="14:00",
                           Tests = new List<Test>()
                           {
                            new Test()
                            {
                            Name = "EF",
                            Description = "Creating Entities"

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
