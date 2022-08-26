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
        private readonly IWebHostEnvironment env;

        public ContactsController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public static List<Contact> contact = new()
        {
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

        public IActionResult Index()
        {
            return View(contact);                         
        }

        public IActionResult Details(int id)
        {
            return View(contact[id-1]);
        }

        public IActionResult SaveAllToFile()
        {
            var path = env.WebRootPath + "/App_Data/contacts.txt";

            var text = "";

            foreach (var contact in contact)
            {
                text += contact.Id + " - " + contact.Name + " - " + contact.Tel + " - "
                   + contact.AltTel + " - " + contact.Email + " - " + contact.Description + Environment.NewLine;
            }

            System.IO.File.AppendAllText(@path, text);

            return RedirectToAction("Index");
        }

        public IActionResult LoadFromFile(FormFile uploadFile)
        {
            string path = env.WebRootPath + "/App_Data/" + uploadFile.FileName;
            int i = 0;
            foreach (var item in System.IO.File.ReadLines(path))
            {
                string[] str = item.Split(" - ");

                contact[i].Id = int.Parse(str[0]);
                contact[i].Name = str[1];
                contact[i].Tel = str[2];
                contact[i].AltTel = str[3];
                contact[i].Email = str[4];
                contact[i].Description = str[5];
                i++;
            }

            return RedirectToAction("Index");
        }
    }
}
