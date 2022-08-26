using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_NET_HW_Module_02_part_03.Models;

namespace ASP_NET_HW_Module_02_part_03.Controllers
{
    public class ContactsController : Controller
    {
        private readonly List<Contact> _contact;

        public ContactsController()
        {
            _contact = new() {
                new Contact{
                    Id = 1,
                    Name = "Jack",
                    Tel = "111-11-11",
                    AltTel = "111-111",
                    Email = "jack@i.ru",
                    Description = "Джек"
                },
                new Contact{
                    Id = 2,
                    Name = "Thomas",
                    Tel = "222-22-22",
                    AltTel = "222-222",
                    Email = "thomas@i.ru",
                    Description = "Томас"
                },
                new Contact{
                    Id = 3,
                    Name = "Oscar",
                    Tel = "333-33-33",
                    AltTel = "333-333",
                    Email = "oscar@i.ru",
                    Description = "Оскар"
                }
            };
        }

        public IActionResult Index()
        {
            return View(_contact);
                          
        }

        public IActionResult Details(int id)
        {
            return View(_contact[id-1]);
        }

        public IActionResult SaveToFile()
        {
            return RedirectToPage("Index");
        }

        public IActionResult LoadFromFile()
        {
            return RedirectToAction();
        }
    }
}
