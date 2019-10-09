using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.Entities;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {

            List<Departament> list = new List<Departament>();
            list.Add(new Departament() { Id = 1, Name = "Eletronics" });
            list.Add(new Departament() { Id = 2, Name = "Fashion" });
            list.Add(new Departament() { Id = 3, Name = "Tools" });
            list.Add(new Departament() { Id = 4, Name = "Games" });

            return View(list);
        }
    }
}