using ASP_NET_HW_Module_02_part_03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ASP_NET_HW_Module_02_part_03.Controllers
{
    public class NotesController : Controller
    {
        private IWebHostEnvironment env;
        public NotesController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public static List<Note> notes = new List<Note>
        {
            new Note
            {
                Id = 1,
                Name = "Note 1",
                Text = "Note text 1",
                Date = DateTime.Now,
                Tags = "<Notes>"
            },
            new Note
            {
                Id = 2,
                Name = "Note 2",
                Text = "Note text 2",
                Date = DateTime.Now,
                Tags = "<Notes>"
            },
            new Note
            {
                Id = 3,
                Name = "Note 3",
                Text = "Note text 3",
                Date = DateTime.Now,
                Tags = "<Notes>"
            }
        };

        // GET: NotesController
        public ActionResult Index()
        {
            return View(notes);
        }

        // GET: NotesController/Details/5
        public ActionResult Details(int id)
        {
            var note = notes.Single(n => n.Id == id);
            return View(note);
        }

        // GET: NotesController/Edit/5
        public ActionResult Edit(int id)
        {
            var note = notes.Single(n => n.Id == id);
            return View(note);
        }

        // POST: NotesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var note = notes.Single(n => n.Id == id);
                TryUpdateModelAsync(note);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //POST: Notes/SaveToFile/0
        public IActionResult SaveToFile(int id)
        {
            var path = env.WebRootPath + "/App_Data/notes.txt";

            var note = notes.Single(n => n.Id == id);

            var res = note.Id + " - " + note.Name + " - " + note.Text + " - "
                + note.Date + " - " + note.Tags + Environment.NewLine;

            System.IO.File.AppendAllText(@path, res);

            return RedirectToAction("Index");
        }

        //POST: Notes/SaveAllToFile
        public IActionResult SaveAllToFile()
        {
            var path = env.WebRootPath + "/App_Data/notes.txt";

            var text = "";

            foreach(var note in notes)
            {
                text += note.Id + " - " + note.Name + " - " + note.Text + " - " 
                   + note.Date + " - " + note.Tags + Environment.NewLine;
            }

            System.IO.File.AppendAllText(@path, text);

            return RedirectToAction("Index");
        }

        //POST: Notes/LoadFromFile
        public IActionResult LoadFromFile(IFormFile uploadFile)
        {
            string path = env.WebRootPath + "/App_Data/" + uploadFile.FileName;
            int i = 0;
            foreach (var item in System.IO.File.ReadLines(path))
            {
                string[] str = item.Split(" - ");

                notes[i].Id = int.Parse(str[0]);
                notes[i].Name = str[1];
                notes[i].Text = str[2];
                notes[i].Date = DateTime.Parse(str[3]);
                notes[i].Tags = str[4];
                i++;
            }

            return RedirectToAction("Index");
        }
    }
}
