using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models;
using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Repositories;
using System.Data;
using System.Reflection;

namespace NordicDoorSuggestionSystem.Controllers
{
    //[Authorize]
    public class SuggestionController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly DataContext _context;
        private readonly ISqlConnector sqlConnector;


        public SuggestionController(
            UserManager<User> userManager,
            IEmployeeRepository employeeRepository,
            ISuggestionRepository suggestionRepository,
            ITeamRepository teamRepository,
            DataContext context, 
            ISqlConnector sqlConnector)



        {
            _userManager = userManager;
            _suggestionRepository = suggestionRepository;
            _context = context;
            _teamRepository = teamRepository;
            this.sqlConnector = sqlConnector;
            this.employeeRepository = employeeRepository;
            
        }

        // GET: Suggestion/Henter  ut Suggestions fra databasen i en liste + legger til søkefunksjon
        // The function is called Index and has the parameter (searchString)
        // First it makes a variabel with a list of the Suggestions
        // Then checks if the string(with the listed items) is Null or Empty.
        // Then it calls the QuerySuggestions() from the SR, with the parameter (searchString).


        [HttpGet]
        public async Task<IActionResult> Index(string title)
        {
            var suggestions = new List<Suggestion>();

            if (title != null)
            {
                suggestions = await _suggestionRepository.QueryTitle(title);
            }
            else
            {
                suggestions = await _suggestionRepository.GetSuggestions();
            }


            var mySuggestions = new List<MySuggestionsViewModel>();
            for (var i = 0; i < suggestions.Count(); i++)
            {

                var responsibleEmployee = employeeRepository.GetEmployeeByNumber(suggestions[i].ResponsibleEmployee.Value);
                var suggestionMaker = employeeRepository.GetEmployeeByNumber(suggestions[i].EmployeeNumber);
                var suggestion = new MySuggestionsViewModel
                {
                    SuggestionID = suggestions[i].SuggestionID,
                    Title = suggestions[i].Title,
                    ResponsibleEmployee = responsibleEmployee.LastName + ", " + responsibleEmployee.FirstName,
                    Problem = suggestions[i].Problem,
                    Solution = suggestions[i].Solution,
                    Goal = suggestions[i].Goal,
                    Deadline = suggestions[i].Deadline,
                    Progress = suggestions[i].Progress,
                    Maker = suggestionMaker.LastName + ", " + suggestionMaker.FirstName,
                    TeamName = suggestions[i].TeamName
                };
                mySuggestions.Add(suggestion);
            }
            return View(mySuggestions);
        }

        // GET: MySuggestions/Henter brukerens suggestions.
        // This function gets the suggestion view and shows the users suggestions.
        // Will test when it is possible to LogIn

        [HttpGet]
        public async Task<IActionResult> MySuggestions(string title)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var suggestions = new List<Suggestion>();

            if (title != null)
            {
                suggestions = await _suggestionRepository.QueryTitleOnResponsible(title, user.EmployeeNumber);
            }
            else
            {
                suggestions = await _suggestionRepository.QueryResponsible(user.EmployeeNumber);
            }
            
            var employee = employeeRepository.GetEmployeeByNumber(user.EmployeeNumber);
            var mySuggestions = new List<MySuggestionsViewModel>();
            for (var i = 0; i < suggestions.Count(); i++)
            {
                var suggestionMaker = employeeRepository.GetEmployeeByNumber(suggestions[i].EmployeeNumber);
                var suggestion = new MySuggestionsViewModel
                {
                    SuggestionID = suggestions[i].SuggestionID,
                    Title = suggestions[i].Title,
                    ResponsibleEmployee = employee.LastName + ", " + employee.FirstName,
                    Problem = suggestions[i].Problem,
                    Solution = suggestions[i].Solution,
                    Goal = suggestions[i].Goal,
                    Deadline = suggestions[i].Deadline,
                    Progress = suggestions[i].Progress,
                    Maker = suggestionMaker.LastName + ", " + suggestionMaker.FirstName,
                    TeamName = suggestions[i].TeamName
                };
                mySuggestions.Add(suggestion);
            }
            return View(mySuggestions);
        }

        [HttpGet]
        public async Task<IActionResult> CreatedSuggestions(string title)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var suggestions = new List<Suggestion>();

            if (title != null)
            {
                suggestions = await _suggestionRepository.QueryTitleOnEmployee(title, user.EmployeeNumber);
            }
            else
            {
                suggestions = await _suggestionRepository.QueryEmployee(user.EmployeeNumber);
            }
            var employee = employeeRepository.GetEmployeeByNumber(user.EmployeeNumber);
            var mySuggestions = new List<MySuggestionsViewModel>();
            for (var i = 0; i < suggestions.Count(); i++)
            {
                var responsibleEmployee = employeeRepository.GetEmployeeByNumber(suggestions[i].ResponsibleEmployee.Value);
                var suggestion = new MySuggestionsViewModel
                {
                    SuggestionID = suggestions[i].SuggestionID,
                    Title = suggestions[i].Title,
                    ResponsibleEmployee = responsibleEmployee.LastName + ", " + responsibleEmployee.FirstName,
                    Problem = suggestions[i].Problem,
                    Solution = suggestions[i].Solution,
                    Goal = suggestions[i].Goal,
                    Deadline = suggestions[i].Deadline,
                    Progress = suggestions[i].Progress,
                    Maker = employee.LastName + ", " + employee.FirstName,
                    TeamName = suggestions[i].TeamName
                };
                mySuggestions.Add(suggestion);
            }
            return View(mySuggestions);
        }

        // GET: Suggestion/Details/Henter detaljer på et Forbedringsforslag
        // The function first checks if the ID = Null in the database.
        // Then gets the id of the selected suggestion and show the fields of the selected Suggestion.

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }

            var suggestion = await _suggestionRepository.GetSuggestion(id);
            var responsible = employeeRepository.GetEmployeeByNumber(suggestion.ResponsibleEmployee.Value);
            if (suggestion == null)
            {
                return NotFound();
            }
            var vm = new SuggestionDetailViewModel
            {
                SuggestionID = suggestion.SuggestionID,
                Title = suggestion.Title,
                ResponsibleEmployee = responsible.LastName + ", " + responsible.FirstName,
                Problem = suggestion.Problem,
                Solution = suggestion.Solution,
                Goal = suggestion.Goal,
                Deadline = suggestion.Deadline,
                TeamName = suggestion.TeamName,
                Progress = suggestion.Progress
            };
            var Comments = _context.Comment.Where(d => d.SuggestionID.Equals(suggestion.SuggestionID)).ToList();
            vm.CommentsList = Comments;

            return View(vm);
        }

        // GET: Suggestion/Create

        [HttpGet]
        public IActionResult Create()
        {
            var employees = _context.Employees.ToList();
            List<SelectListItem> responsibleItems = new List<SelectListItem>();
            for (var i = 0; i < employees.Count(); i++)
            {
                responsibleItems.Add(new SelectListItem()
                {
                    Value = employees[i].EmployeeNumber.ToString(),
                    Text = employees[i].LastName + ", " + employees[i].FirstName
                });
            }
            var createSgstnViewModel = new CreateSuggestionViewModel
            {
                ResponsibleList = responsibleItems                
            };
            return View(createSgstnViewModel);
        }

        // POST: Suggestion/Create/Lage et nytt Forbedringsforslag
        // The function creates a new Suggestion.
        // The function maps the Suggestion.cs to the SuggestionViewModel and calls the Add() function from SuggestionRepository.
        // Then it calls the SaveChanges() from SR and returns to the index view.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSuggestionViewModel createSuggestionViewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var maker = employeeRepository.GetEmployeeByNumber(user.EmployeeNumber);
            if (maker.CreatedSuggestions == null)
            {
                maker.CreatedSuggestions = 0;
                if (maker.CompletedSuggestions == null)
                {
                    maker.CompletedSuggestions = 0;
                }
                employeeRepository.Update(maker);
            }
            
            if (ModelState.IsValid)
            {
                if (createSuggestionViewModel.ResponsibleEmployee != null)
                {
                    var responsible = employeeRepository.GetEmployeeByNumber(Int32.Parse(createSuggestionViewModel.ResponsibleEmployee));
                    if (responsible.TeamID != null)
                    {
                        if (createSuggestionViewModel.Progress == null)
                        {
                            createSuggestionViewModel.Progress = "Plan";
                        }
                        var team = _teamRepository.GetTeam(responsible.TeamID);
                        var newsuggestion = new Suggestion
                        {
                            Title = createSuggestionViewModel.Title,
                            ResponsibleEmployee = Int32.Parse(createSuggestionViewModel.ResponsibleEmployee),
                            Problem = createSuggestionViewModel.Problem,
                            Solution = createSuggestionViewModel.Solution,
                            Goal = createSuggestionViewModel.Goal,
                            Deadline = createSuggestionViewModel.Deadline,
                            Progress = createSuggestionViewModel.Progress,
                            EmployeeNumber = maker.EmployeeNumber,
                            TeamID = responsible.TeamID,
                            TeamName = team.TeamName
                        };                        
                        maker.CreatedSuggestions++;
                        employeeRepository.Update(maker);
                        await _suggestionRepository.Add(newsuggestion);
                        await _suggestionRepository.SaveChanges();
                        return RedirectToAction(nameof(MySuggestions));
                    }
                }
                else if (createSuggestionViewModel.ResponsibleEmployee == null && maker.TeamID != null)
                {
                    if (createSuggestionViewModel.Progress == null)
                    {
                        createSuggestionViewModel.Progress = "Plan";
                    }
                    var team = _teamRepository.GetTeam(maker.TeamID);
                    var newSuggestion = new Suggestion
                    {
                        Title = createSuggestionViewModel.Title,
                        ResponsibleEmployee = maker.EmployeeNumber,
                        Problem = createSuggestionViewModel.Problem,
                        Solution = createSuggestionViewModel.Solution,
                        Goal = createSuggestionViewModel.Goal,
                        Deadline = createSuggestionViewModel.Deadline,
                        Progress = createSuggestionViewModel.Progress,
                        EmployeeNumber = maker.EmployeeNumber,
                        TeamID = maker.TeamID,
                        TeamName = team.TeamName
                    };
                    maker.CreatedSuggestions++;
                    employeeRepository.Update(maker);
                    await _suggestionRepository.Add(newSuggestion);
                    await _suggestionRepository.SaveChanges();
                    return RedirectToAction(nameof(MySuggestions));
                }
            }
            return View(createSuggestionViewModel);
        }

        // GET: Suggestion/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }

            var suggestion = await _suggestionRepository.GetSuggestion(id);
            if (suggestion == null)
            {
                return NotFound();
            }
            var employees = _context.Employees.ToList();
            for (var i = employees.Count()-1; i >= 0; i--)
            {
                if (employees[i].TeamID == null)
                {
                    employees.Remove(employees[i]);
                }
            }
            List<SelectListItem> responsibleItems = new List<SelectListItem>();
            for (var i = 0; i < employees.Count(); i++)
            {
                responsibleItems.Add(new SelectListItem()
                {
                    Value = employees[i].EmployeeNumber.ToString(),
                    Text = employees[i].LastName + ", " + employees[i].FirstName
                });
            }
            List<SelectListItem> progressItems = new List<SelectListItem>();
            progressItems.Add(new SelectListItem()
            {
                Value = "Plan",
                Text = "Plan"
            });
            progressItems.Add(new SelectListItem()
            {
                Value = "Do",
                Text = "Do"
            });
            progressItems.Add(new SelectListItem()
            {
                Value = "Study",
                Text = "Study"
            });
            progressItems.Add(new SelectListItem()
            {
                Value = "Act",
                Text = "Act"
            });
            var editSuggestionViewModel = new EditSuggestionViewModel {
                Title = suggestion.Title,
                ResponsibleList = responsibleItems,
                ResponsibleEmployee = suggestion.ResponsibleEmployee.ToString(),
                Problem = suggestion.Problem,
                Solution = suggestion.Solution,
                Goal = suggestion.Goal,
                ProgressList = progressItems,
                Progress = suggestion.Progress,
                Deadline = suggestion.Deadline,
                TeamID = suggestion.TeamID.Value
            };
           

            return View(editSuggestionViewModel);
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title, ResponsibleEmployee, Problem, Solution, Goal, Progress, Deadline, TeamID")] EditSuggestionViewModel editSuggestionViewModel)
        {
            var suggestion = await _suggestionRepository.GetSuggestion(id);
            if (suggestion == null)
            {
                return NotFound();
            }
            if (editSuggestionViewModel.TeamID == null)
            {
                editSuggestionViewModel.TeamID = 1; // just to make it work
            }
            if (editSuggestionViewModel.ResponsibleEmployee != null)
            {
                var responsibleEmployee = employeeRepository.GetEmployeeByNumber(Int32.Parse(editSuggestionViewModel.ResponsibleEmployee));
                var team = _teamRepository.GetTeam(responsibleEmployee.TeamID);
                var employee = employeeRepository.GetEmployeeByNumber(suggestion.ResponsibleEmployee.Value);
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (editSuggestionViewModel.TeamID == null)
                        {
                            editSuggestionViewModel.TeamID = 1; //just to stop the crash, not enough time to actually fix
                        }
                        suggestion.Title = editSuggestionViewModel.Title;
                        suggestion.ResponsibleEmployee = Int32.Parse(editSuggestionViewModel.ResponsibleEmployee);
                        suggestion.Problem = editSuggestionViewModel.Problem;
                        suggestion.Solution = editSuggestionViewModel.Solution;
                        suggestion.Goal = editSuggestionViewModel.Goal;
                        suggestion.Progress = editSuggestionViewModel.Progress;
                        suggestion.Deadline = editSuggestionViewModel.Deadline;
                        suggestion.TeamID = responsibleEmployee.TeamID;
                        suggestion.TeamName = team.TeamName;

                        await _suggestionRepository.Update(suggestion);
                        await _suggestionRepository.SaveChanges();
                        if (suggestion.Progress == "Act")
                        {
                            employee.CompletedSuggestions++;
                            team.TeamSgstnCount++;
                            employeeRepository.Update(employee);
                            await _teamRepository.UpdateTeam(team);
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                var responsibleEmployee = employeeRepository.GetEmployeeByNumber(suggestion.ResponsibleEmployee.Value);
                var team = _teamRepository.GetTeam(responsibleEmployee.TeamID);
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (editSuggestionViewModel.TeamID == null)
                        {
                            editSuggestionViewModel.TeamID = 1; //just to stop the crash, not enough time to actually fix
                        }
                        suggestion.Title = editSuggestionViewModel.Title;
                        suggestion.ResponsibleEmployee = Int32.Parse(editSuggestionViewModel.ResponsibleEmployee);
                        suggestion.Problem = editSuggestionViewModel.Problem;
                        suggestion.Solution = editSuggestionViewModel.Solution;
                        suggestion.Goal = editSuggestionViewModel.Goal;
                        suggestion.Progress = editSuggestionViewModel.Progress;
                        suggestion.Deadline = editSuggestionViewModel.Deadline;
                        suggestion.TeamID = responsibleEmployee.TeamID;
                        suggestion.TeamName = team.TeamName;

                        await _suggestionRepository.Update(suggestion);
                        await _suggestionRepository.SaveChanges();
                        if (suggestion.Progress == "Act")
                        {
                            responsibleEmployee.CompletedSuggestions++;
                            team.TeamSgstnCount++;
                            employeeRepository.Update(responsibleEmployee);
                            await _teamRepository.UpdateTeam(team);
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            

            
            return View(suggestion);
        }

        // GET: Suggestion/Henter ut et Forslag fra databasen som skal slettes.
        // This function called Delete with the parameter (int? id)
        // First checks if id = null. If null, return NotFound()
        // Then it calls the GetSuggestion() from SR
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }

            var suggestion = await _suggestionRepository.GetSuggestion(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            return View(suggestion);
        }

        // POST: Suggestion/Delete/Sletter et Forslag fra databasen
        // This function is based on the function Delete(int? id).
        // It first calls the GetSuggestions() from SR, and checks if Suggestions exists in the database.
        // Then it calls the GetSuggestion with the parameter (id).
        // and then the function Delete from the SR with the parameter (suggestion).
        // Then update the database with the SaveChanges() from SR.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _suggestionRepository.GetSuggestions() == null)
            {
                return Problem("Entity set 'DataContext.Suggestion'  is null.");
            }
            var suggestion = await _suggestionRepository.GetSuggestion(id);
            if (suggestion != null)
            {
                await _suggestionRepository.Delete(suggestion);
                await _suggestionRepository.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }

        private bool SuggestionEntityExists(int id)
        {
          var suggestion = _suggestionRepository.GetSuggestion(id);

          if(suggestion == null) return false;
          return true;
        }

        public Task<List<Comment>> GetComments() => _context.Comment.ToListAsync();

        public async Task<IActionResult> AddComment(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }

            var comment = await _suggestionRepository.GetSuggestion(id);
            if (comment == null)
            {
                return NotFound();
            }
            var addSuggestionComment = new AddSuggestionComment {
                SuggestionID = comment.SuggestionID
            };

            return View(addSuggestionComment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("CommentID, EmployeeNumber,SuggestionID, Content, CommentTime")] AddSuggestionComment comment)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            
            {
                var newComment = new Comment {
                    EmployeeNumber = user.EmployeeNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SuggestionID = comment.SuggestionID,
                    Content = comment.Content,
                    CommentTime = DateTime.Now,
                };

                _context.Add(newComment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Suggestion", new {id = comment.SuggestionID});
            }
            return View();
        }

        public IActionResult TeamSuggestions()
        {
            return View();
        }

        public IActionResult Feed()
        {
            return View();
        }

        private void RunCommand(string sql)
        {
            using (var connection = sqlConnector.GetDbConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private IDataReader ReadData(string query, IDbConnection connection)
        {
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            return command.ExecuteReader();
        }

        [HttpGet]
        public async Task<IActionResult> AllSuggestions(string title)
        {
            var suggestions = new List<Suggestion>();

            if (title != null)
            {
                suggestions = await _suggestionRepository.QueryTitle(title);
            } else {
                suggestions = await _suggestionRepository.GetSuggestions();
            }

            
            var mySuggestions = new List<MySuggestionsViewModel>();
            for (var i = 0; i < suggestions.Count(); i++)
            {
                
                var responsibleEmployee = employeeRepository.GetEmployeeByNumber(suggestions[i].ResponsibleEmployee.Value);
                var suggestionMaker = employeeRepository.GetEmployeeByNumber(suggestions[i].EmployeeNumber);
                var suggestion = new MySuggestionsViewModel
                {
                    SuggestionID = suggestions[i].SuggestionID,
                    Title = suggestions[i].Title,
                    ResponsibleEmployee = responsibleEmployee.LastName + ", " + responsibleEmployee.FirstName,
                    Problem = suggestions[i].Problem,
                    Solution = suggestions[i].Solution,
                    Goal = suggestions[i].Goal,
                    Deadline = suggestions[i].Deadline,
                    Progress = suggestions[i].Progress,
                    Maker = suggestionMaker.LastName + ", " + suggestionMaker.FirstName,
                    TeamName = suggestions[i].TeamName
                };
                mySuggestions.Add(suggestion);
            }
            return View(mySuggestions);
        }
    }

}


