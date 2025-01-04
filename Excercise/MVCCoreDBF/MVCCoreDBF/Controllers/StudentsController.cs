using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVCCoreDBF.Models;

namespace MVCCoreDBF.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MvcdbContext _context;
        private readonly IWebHostEnvironment _environment;

        public StudentsController(MvcdbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public async Task<IActionResult> Create([Bind("Sid, Name, Class, Fees, Photo, Status")] Student student, IFormFile selectedFile)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid || (ModelState.ErrorCount == 1 && ModelState["selectedFile"].ValidationState == ModelValidationState.Invalid))
                {
                    string FolderPath =  _environment.WebRootPath + "\\images";
                    if (!Directory.Exists(FolderPath))
                    {
                        Directory.CreateDirectory(FolderPath);
                    }
                    string FilePath = FolderPath + "\\" + selectedFile.FileName;
                    FileStream fs = new FileStream(FilePath, FileMode.Create);
                    selectedFile.CopyTo(fs);
                    student.Photo = selectedFile.FileName;
                }
                student.Status = true;
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sid,Name,Class,Fees,Photo,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            if (student.Photo != null)
            {
                TempData["Photo"] = student.Photo;
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sid,Name,Class,Fees,Photo,Status")] Student student, IFormFile selectedFile)
        {
            if (id != student.Sid)
            {
                return NotFound();
            }
            if (ModelState.IsValid || (ModelState.ErrorCount == 1 && ModelState["selectedFile"].ValidationState == ModelValidationState.Invalid))
            {
                try
                {
                    if (selectedFile != null)
                    {
                        string FolderPath = Path.Combine(_environment.WebRootPath, "images");
                        if (!Directory.Exists(FolderPath))
                        {
                            Directory.CreateDirectory(FolderPath);
                        }
                        string ImagePath = Path.Combine(FolderPath, selectedFile.FileName);
                        FileStream fs = new FileStream(ImagePath, FileMode.Create);
                        selectedFile.CopyTo(fs);
                        student.Photo = selectedFile.FileName;
                    }
                    else if (TempData["Photo"] != null)
                    {
                        student.Photo = TempData["Photo"].ToString();
                    }
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Sid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Sid == id);
        }
    }
}
