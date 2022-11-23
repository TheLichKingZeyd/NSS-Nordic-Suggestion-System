using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using NordicDoorSuggestionSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using NordicDoorSuggestionSystem.Models.Account;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoorSuggestionSystem.Controllers
{
    private readonly UserManager<User> _userManager;
    public class ProfilePageController : Controller
    {
        public ProfilePageController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Statistic()
        {
            return View();
        }
    }


    //byte[] picture ???
    [HttpGet]
    public async Task<IActionResult> UploadProfilePicture(FormCollection form)
    {
        var user = await _userManager.FindByIdAsync(id);
        var currentUser = _userManager.GetUserAsync(HttpContext.User);
        employee.ProfilePicture = form["NewImageData"]; // Employee or employee ?
        user.EmployeeNumber ;

    }






}

