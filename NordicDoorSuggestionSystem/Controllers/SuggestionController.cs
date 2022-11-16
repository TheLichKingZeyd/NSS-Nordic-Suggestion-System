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

namespace NordicDoorSuggestionSystem.Controllers
{
    //[Authorize]
    public class SuggestionController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly ISuggestionRepository _suggestionRepository;
        private readonly DataContext _context;
        private readonly ISqlConnector sqlConnector;


        public SuggestionController(UserManager<User> userManager, ISuggestionRepository suggestionRepository, DataContext context, ISqlConnector sqlConnector)


        {
            _userManager = userManager;
            _suggestionRepository = suggestionRepository;
            _context = context;
            this.sqlConnector = sqlConnector;
        }

        // GET: Suggestion/Henter  ut Suggestions fra databasen i en liste + legger til søkefunksjon
        // The function is called Index and has the parameter (searchString)
        // First it makes a variabel with a list of the Suggestions
        // Then checks if the string(with the listed items) is Null or Empty.
        // Then it calls the QuerySuggestions() from the SR, with the parameter (searchString).


        public async Task<IActionResult> Index(string title)
        {
            var suggestions = new List<Suggestion>();
            if (!String.IsNullOrEmpty(title))
            {
                suggestions = await _suggestionRepository.QueryTitle(title);
            } else {
                suggestions = await _suggestionRepository.GetSuggestions();
            }
           /* if (!String.IsNullOrEmpty(problem))
            {
                suggestions = await _suggestionRepository.QueryProblem(problem);
            }*/
              return View(suggestions);
        }

        // GET: MySuggestions/Henter brukerens suggestions.
        // This function gets the suggestion view and shows the users suggestions.
        // Will test when it is possible to LogIn

        public async Task<IActionResult> MySuggestions()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var suggestions = await _suggestionRepository.QueryEmployee(user.EmployeeNumber);  
            return View(suggestions);
        }

        // GET: Suggestion/Details/Henter detaljer på et Forbedringsforslag
        // The function first checks if the ID = Null in the database.
        // Then gets the id of the selected suggestion and show the fields of the selected Suggestion.

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }

            var suggestion = await _suggestionRepository.GetSuggestion(id);
            SuggestionDetailViewModel vm = new SuggestionDetailViewModel();
            if (suggestion == null)
            {
                return NotFound();
            }

            vm.SuggestionID = suggestion.SuggestionID;
            vm.Title = suggestion.Title;
            vm.ResponsibleEmployee = suggestion.ResponsibleEmployee;
            vm.Problem = suggestion.Problem;
            vm.Solution = suggestion.Solution;
            vm.Goal = suggestion.Goal;
            vm.Deadline = suggestion.Deadline;
            vm.TeamID = suggestion.TeamID;

            var Comments = _context.Comment.Where(d => d.SuggestionID.Equals(suggestion.SuggestionID)).ToList();
            vm.CommentsList = Comments;

            return View(vm);
        }

        // GET: Suggestion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suggestion/Create/Lage et nytt Forbedringsforslag
        // The function creates a new Suggestion.
        // The function maps the Suggestion.cs to the SuggestionViewModel and calls the Add() function from SuggestionRepository.
        // Then it calls the SaveChanges() from SR and returns to the index view.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ResponsibleEmployee, Problem, Solution, Goal, Deadline, Progress, EmployeeNumber, TeamID")] SuggestionViewModel suggestionViewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var newSuggestion = new Suggestion {
                    Title = suggestionViewModel.Title,
                    ResponsibleEmployee = suggestionViewModel.ResponsibleEmployee,
                    Problem = suggestionViewModel.Problem,
                    Solution = suggestionViewModel.Solution,
                    Goal = suggestionViewModel.Goal,
                    Deadline = suggestionViewModel.Deadline,
                    Progress = suggestionViewModel.Progress,
                    EmployeeNumber = user.EmployeeNumber,
                    TeamID = suggestionViewModel.TeamID
                };

                  var sql = $@"update team 
                                set 
                                   TeamSgstnCount = TeamSgstnCount + 1
                                where TeamID = '{suggestionViewModel.TeamID}';";
            RunCommand(sql);

            var sql2 = $@"update employee 
                                set 
                                   SuggestionCount = SuggestionCount + 1
                                where EmployeeNumber = '{user.EmployeeNumber}';";
            RunCommand(sql2);

                await _suggestionRepository.Add(newSuggestion);
                await _suggestionRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(suggestionViewModel);
        }

        // GET: Suggestion/Edit/5
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

            var editSuggestionViewModel = new EditSuggestionViewModel {
                Title = suggestion.Title,
                ResponsibleEmployee = suggestion.ResponsibleEmployee,
                Problem = suggestion.Problem,
                Solution = suggestion.Solution,
                Goal = suggestion.Goal,
                Deadline = suggestion.Deadline,
                TeamID = suggestion.TeamID
            };

            return View(editSuggestionViewModel);
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title, ResponsibleEmployee, Problem, Solution, Goal, Deadline, TeamID")] EditSuggestionViewModel editSuggestionViewModel)
        {
            var suggestion = await _suggestionRepository.GetSuggestion(id);
            if ( suggestion == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    suggestion.Title = editSuggestionViewModel.Title;
                    suggestion.ResponsibleEmployee = editSuggestionViewModel.ResponsibleEmployee;
                    suggestion.Problem = editSuggestionViewModel.Problem;
                    suggestion.Solution = editSuggestionViewModel.Solution;
                    suggestion.Goal = editSuggestionViewModel.Goal;
                    suggestion.Deadline = editSuggestionViewModel.Deadline;
                    suggestion.TeamID = editSuggestionViewModel.TeamID;

                    await _suggestionRepository.Update(suggestion);
                    await _suggestionRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(suggestion);
        }

        // GET: Suggestion/Henter ut et Forslag fra databasen som skal slettes.
        // This function called Delete with the parameter (int? id)
        // First checks if id = null. If null, return NotFound()
        // Then it calls the GetSuggestion() from SR
        //
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

            var sql = $@"update team 
                                set 
                                   TeamSgstnCount = TeamSgstnCount - 1
                                where TeamID = '{suggestion.TeamID}';";
            RunCommand(sql);

            var sql2 = $@"update employee 
                                set 
                                   SuggestionCount = SuggestionCount - 1
                                where EmployeeNumber = '{suggestion.EmployeeNumber}';";
            RunCommand(sql2);

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
        public async Task<IActionResult> AddComment([Bind("CommentID, EmployeeNumber,SuggestionID, Content, CommentTime")] Comment comment)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            
            {
                var newComment = new Comment {
                    CommentID = comment.CommentID,
                    EmployeeNumber = user.EmployeeNumber,
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
    }

}


