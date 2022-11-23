using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using NordicDoorSuggestionSystem.Models.Account;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;
using NordicDoorSuggestionSystem.Models.Administrate;

namespace NordicDoorSuggestionSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmployeeRepository userRepository,
            IEmailSender emailSender,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.employeeRepository = userRepository;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<AccountController>();


            // Set up a testuser for test purposes
            // var user = new User
            // {
            //     UserName = "123456",
            //     EmployeeNumber = 123456,
            //     FirstName = "Test",
            //     LastName = "Testersen",
            //     Role = "Administrator",
            //     LockoutEnabled = false,
            //     LockoutEnd = null
            // };
            // var password = "123Asd";

            // _userManager.CreateAsync(user, password);
            // _userManager.AddToRoleAsync(user, "Administrator");

            // var employee = new Employee
            // {
            //     EmployeeNumber = user.EmployeeNumber,
            //     FirstName = user.FirstName,
            //     LastName = user.LastName,
            //     Role = user.Role,
            //     SuggestionCount = 0
            // };
            // employeeRepository.Add(employee);
            // // End of setting up testuser for test purposes
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.EmployeeNumber, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToLocal(returnUrl);
                }                
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string? returnUrl = null)
        {
            if (!await _roleManager.RoleExistsAsync("Administrator"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
                await _roleManager.CreateAsync(new IdentityRole("Team Leder"));
                await _roleManager.CreateAsync(new IdentityRole("Standard Bruker"));
            }
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Standard Bruker",
                Text = "Standard Bruker"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Team Leder",
                Text = "Team Leder"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Administrator",
                Text = "Administrator"
            });
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.RoleList = listItems;
            ViewData["ReturnUrl"] = returnUrl;
            return View(registerViewModel);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = registerViewModel.EmployeeNumber.ToString(),
                    EmployeeNumber = registerViewModel.EmployeeNumber,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Role = registerViewModel.RoleSelected,
                    LockoutEnabled = false,
                    LockoutEnd = null };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    if(registerViewModel.RoleSelected != null && registerViewModel.RoleSelected.Length > 0)
                    {
                        if (registerViewModel.RoleSelected == "Standard Bruker")
                        {
                            await _userManager.AddToRoleAsync(user, "Standard Bruker");
                        }
                        else if (registerViewModel.RoleSelected == "Team Leder")
                        {
                            await _userManager.AddToRoleAsync(user, "Team Leder");
                        }
                        else if (registerViewModel.RoleSelected == "Administrator")
                        {
                            await _userManager.AddToRoleAsync(user, "Administrator");
                        }
                    }

                    var newModel = new RegisterViewModel
                    {
                        RoleList = registerViewModel.RoleList
                    };
                    var employee = new Employee {
                        EmployeeNumber = registerViewModel.EmployeeNumber,
                        FirstName = registerViewModel.FirstName,
                        LastName = registerViewModel.LastName,
                        Role = registerViewModel.RoleSelected,
                        SuggestionCount = 0
                    };                    

                    employeeRepository.Add(employee);

                    _logger.LogInformation(3, "User created a new account with password.");


                    return RedirectToAction("Register");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

   
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string? code = null)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(AccountController.ResetPasswordConfirmation), "Account");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(AccountController.ResetPasswordConfirmation), "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }




        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private Task<User> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
