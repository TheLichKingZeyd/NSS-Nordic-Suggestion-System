﻿using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models.Employees;
using NordicDoorSuggestionSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace NordicDoorSuggestionSystem.Controllers
{
    // [Authorize]
    public class AdministrateEmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public AdministrateEmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        

        [HttpPost]
        public IActionResult Save(EmployeeViewModel model)
        {
            Employee newEmployeeAccount = new Employee
            {
                EmployeeNumber = model.EmployeeNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                SuggestionCount = 0
            };
            var roles = new List<string>();
            if (model.Role == "Administrator")
            {
                roles.Add("Administrator");
            }
            else if (model.Role == "Team Leader")
            {
                //roles.Add();
            }

            employeeRepository.Add(newEmployeeAccount);
            //AccountController.Register(model, "");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int EmployeeNumber)
        {
            employeeRepository.Delete(EmployeeNumber);
            return RedirectToAction("Index");
        }
    }
}