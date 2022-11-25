using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace NordicDoorSuggestionSystem.DataAccess
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.EnsureCreated();

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new List<Employee>()
                    {
                        new Employee()
                        {
                            EmployeeNumber = 123456,
                            FirstName = "Admin",
                            LastName = "User",
                            ProfilePicture = null,
                            CompletedSuggestions = 1,
                            CreatedSuggestions = 4,
                            Role = "Administrator",
                            TeamID = 1,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 111111,
                            FirstName = "Ola",
                            LastName = "Nordmann",
                            ProfilePicture = null,
                            CompletedSuggestions = 0,
                            CreatedSuggestions = 2,
                            Role = "Team Leder",
                            TeamID = 2,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 333333,
                            FirstName = "Henrik",
                            LastName = "Larsen",
                            ProfilePicture = null,
                            CompletedSuggestions = 1,
                            CreatedSuggestions = 1,
                            Role = "Team Leder",
                            TeamID = 3,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 444444,
                            FirstName = "Fredrik",
                            LastName = "Aker",
                            ProfilePicture = null,
                            CompletedSuggestions = 1,
                            CreatedSuggestions = 3,
                            Role = "Team Leder",
                            TeamID = 4,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 555555,
                            FirstName = "Geir",
                            LastName = "Henriksen",
                            ProfilePicture = null,
                            CompletedSuggestions = 0,
                            CreatedSuggestions = 0,
                            Role = "Standard Bruker",
                            TeamID = null,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 666666,
                            FirstName = "Andre",
                            LastName = "Franz",
                            ProfilePicture = null,
                            CompletedSuggestions = 0,
                            CreatedSuggestions = 0,
                            Role = "Standard Bruker",
                            TeamID = null,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 777777,
                            FirstName = "Aleksander",
                            LastName = "Lund",
                            ProfilePicture = null,
                            CompletedSuggestions = 0,
                            CreatedSuggestions = 0,
                            Role = "Standard Bruker",
                            TeamID = 1,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 888888,
                            FirstName = "Asgeir",
                            LastName = "Worren",
                            ProfilePicture = null,
                            CompletedSuggestions = 0,
                            CreatedSuggestions = 0,
                            Role = "Standard Bruker",
                            TeamID = 2,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 999999,
                            FirstName = "Asgeir",
                            LastName = "Worren",
                            ProfilePicture = null,
                            CompletedSuggestions = 0,
                            CreatedSuggestions = 0,
                            Role = "Standard Bruker",
                            TeamID = 3,
                        },
                        new Employee()
                        {
                            EmployeeNumber = 222222,
                            FirstName = "Kristian",
                            LastName = "Berntsen",
                            ProfilePicture = null,
                            CompletedSuggestions = 0,
                            CreatedSuggestions = 0,
                            Role = "Standard Bruker",
                            TeamID = 4,
                        }
                    });
                }

                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(new List<Department>()
                    {
                        new Department()
                        {
                            DepartmentID = 1,
                            DepartmentName = "Administrajon"
                        },
                        new Department()
                        {
                            DepartmentID = 2,
                            DepartmentName = "Oljing"
                        },
                        new Department()
                        {
                            DepartmentID = 3,
                            DepartmentName = "Regnskap"
                        },
                        new Department()
                        {
                            DepartmentID = 4,
                            DepartmentName = "Sag"
                        }
                    });
                }

                if (!context.Team.Any())
                {
                    context.Team.AddRange(new List<Team>()
                    {
                        new Team()
                        {
                            TeamID = 1,
                            TeamName = "Team 1",
                            TeamLeader = 123456,
                            DepartmentID = 1,
                            TeamSgstnCount = 1

                        },
                        new Team()
                        {
                            TeamID = 2,
                            TeamName = "Team 2",
                            TeamLeader = 111111,
                            DepartmentID = 2,
                            TeamSgstnCount = 0
                        },
                        new Team()
                        {
                            TeamID = 3,
                            TeamName = "Team 3",
                            TeamLeader = 444444,
                            DepartmentID = 3,
                            TeamSgstnCount = 1
                        },
                        new Team()
                        {
                            TeamID = 4,
                            TeamName = "Team 4",
                            TeamLeader = 333333,
                            DepartmentID = 4,
                            TeamSgstnCount = 1
                        }
                    });
                }

                if (!context.Suggestion.Any())
                {
                    context.Suggestion.AddRange(new List<Suggestion>()
                    {
                        new Suggestion()
                        {
                            SuggestionID = 1,
                            ResponsibleEmployee = 123456,
                            Title = "Trenger mer farge",
                            Problem = "Vi i produksjon trenger flere farger å velge mellom",
                            Solution = "Kjøpe flere farger inn på lager",
                            Goal = "Lage flere ulike og forskjellige dører med farger",
                            Deadline = new DateTime(2023,1,1,16,30,00),
                            Progress = "Do",
                            EmployeeNumber = 123456,
                            TeamID = 1,
                            TeamName = "Team 1"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 2,
                            ResponsibleEmployee = 123456,
                            Title = "Ny dør",
                            Problem = "Den gamle døren er ødelagt",
                            Solution = "Får ikke lukket døren til kontoret",
                            Goal = "Kjøpe eller lage en ny dør. Må monteres",
                            Deadline = new DateTime(2022,12,19,08,30,00),
                            Progress = "Study",
                            EmployeeNumber = 123456,
                            TeamID = 1,
                            TeamName = "Team 1"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 3,
                            ResponsibleEmployee = 222222,
                            Title = "Mer mat i kantina",
                            Problem = "Vi på team 1 vil ha mer mat i kantina",
                            Solution = "Handle inn mer mat til kantina",
                            Goal = "Forbedre matkvaliteten og utvalget i kantina",
                            Deadline = new DateTime(2023,2,10,16,00,00),
                            Progress = "Plan",
                            EmployeeNumber = 123456,
                            TeamID = 1,
                            TeamName = "Team 1"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 4,
                            ResponsibleEmployee = 111111,
                            Title = "Dårlig tap-maskin",
                            Problem = "Den gamle tap-maskinen er gammel og utdatert",
                            Solution = "Kjøpe en ny maskin.",
                            Goal = "Forbedre produksjonssevne",
                            Deadline = new DateTime(2023,9,14,13,30,00),
                            Progress = "Plan",
                            EmployeeNumber = 111111,
                            TeamID = 2,
                            TeamName = "Team 2"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 5,
                            ResponsibleEmployee = 333333,
                            Title = "Ny ansatt",
                            Problem = "Vi er nedbemmannet",
                            Solution = "Ansette en ny ansatt",
                            Goal = "Forbedre produksjonsevne",
                            Deadline = new DateTime(2022,11,11,16,30,00),
                            Progress = "Act",
                            EmployeeNumber = 333333,
                            TeamID = 3,
                            TeamName = "Team 3"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 6,
                            ResponsibleEmployee = 444444,
                            Title = "Snus på gulv og i vinduskarmer",
                            Problem = "Det er et problem at folk ikke kaster snus i søppelkassa",
                            Solution = "Ha en team talk med alle ansatte",
                            Goal = "Forebygge forsøpling",
                            Deadline = new DateTime(2022,10,1,16,30,00),
                            Progress = "Act",
                            EmployeeNumber = 444444,
                            TeamID = 4,
                            TeamName = "Team 4"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 7,
                            ResponsibleEmployee = 111111,
                            Title = "Ødelagt maskin",
                            Problem = "Den gamle maskinen er ødelagt",
                            Solution = "Kjøpe ny maskin",
                            Goal = "Forbedre produksjonsevne",
                            Deadline = new DateTime(2023,5,21,10,30,00),
                            Progress = "Study",
                            EmployeeNumber = 111111,
                            TeamID = 2,
                            TeamName = "Team 2"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 8,
                            ResponsibleEmployee = 123456,
                            Title = "Vi trenger mer arbeidsmoral",
                            Problem = "Lange arbeidsdager, lite betalt",
                            Solution = "Kjøp en kake ellerno idk",
                            Goal = "Vi er fornøyde",
                            Deadline = new DateTime(2023,9,1,16,30,00),
                            Progress = "Do",
                            EmployeeNumber = 444444,
                            TeamID = 3,
                            TeamName = "Team 3"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 9,
                            ResponsibleEmployee = 777777,
                            Title = "Trenger mer farge",
                            Problem = "Vi i produksjon trenger flere farger å velge mellom",
                            Solution = "Kjøpe flere farger inn på lager",
                            Goal = "Lage flere ulike og forskjellige dører med farger",
                            Deadline = new DateTime(2023,1,1,16,30,00),
                            Progress = "Do",
                            EmployeeNumber = 123456,
                            TeamID = 1,
                            TeamName = "Team 1"
                        },
                        new Suggestion()
                        {
                            SuggestionID = 10,
                            ResponsibleEmployee = 123456,
                            Title = "Trenger sterkere lim",
                            Problem = "Limet på dørene er dårlig",
                            Solution = "Legge inn en bestilling på noe bedre",
                            Goal = "Limet er av god kvalitet",
                            Deadline = new DateTime(2022,12,1,16,30,00),
                            Progress = "Act",
                            EmployeeNumber = 444444,
                            TeamID = 4,
                            TeamName = "Team 4"
                        },
                    });
                }
                context.SaveChanges();
            }
            SeedUsersAsync(applicationBuilder);
        }

        public static async Task SeedUsersAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Administrator"))
                    await roleManager.CreateAsync(new IdentityRole("Administrator"));
                if (!await roleManager.RoleExistsAsync("Standard Bruker"))
                    await roleManager.CreateAsync(new IdentityRole("Standard Bruker"));
                if (!await roleManager.RoleExistsAsync("Team Leder"))
                    await roleManager.CreateAsync(new IdentityRole("Team Leder"));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var newAdminUser = new User()
                {
                    EmployeeNumber = 123456,
                    FirstName = "Admin",
                    LastName = "User",
                    Role = "Administrator",
                    UserName = "123456",
                    NormalizedUserName = "123456",
                    LockoutEnabled = false,
                    LockoutEnd = null,
                };
                await userManager.CreateAsync(newAdminUser, "Root123");
                await userManager.AddToRoleAsync(newAdminUser, newAdminUser.Role);
            }
        }
    }
}