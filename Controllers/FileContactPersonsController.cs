using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AISV1.Data;
using AISV2.Models;

namespace AISV2.Controllers
{
    public class FileContactPersonsController : Controller
    {
        private readonly AISContext _context;

        public FileContactPersonsController(AISContext context)
        {
            _context = context;
        }

        // GET: FileContactPersons
        public async Task<IActionResult> Index()
        {
            var aISContext = _context.FileContactPersons.Include(f => f.ContactPerson).Include(f => f.File);
            return View(await aISContext.ToListAsync());
        }

        // GET: FileContactPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileContactPerson = await _context.FileContactPersons
                .Include(f => f.ContactPerson)
                .Include(f => f.File)
                .FirstOrDefaultAsync(m => m.FileContactPersonID == id);
            if (fileContactPerson == null)
            {
                return NotFound();
            }

            return View(fileContactPerson);
        }

        // GET: FileContactPersons/Create
        public IActionResult Create()
        {
            ViewData["ContactPersonID"] = new SelectList(_context.ContactPersons, "ContactPersonID", "ContactPersonID");
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId");
            return View();
        }

        // POST: FileContactPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FileContactPersonID,FileID,ContactPersonID")] FileContactPerson fileContactPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileContactPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactPersonID"] = new SelectList(_context.ContactPersons, "ContactPersonID", "ContactPersonID", fileContactPerson.ContactPersonID);
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId", fileContactPerson.FileID);
            return View(fileContactPerson);
        }

        // GET: FileContactPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileContactPerson = await _context.FileContactPersons.FindAsync(id);
            if (fileContactPerson == null)
            {
                return NotFound();
            }
            ViewData["ContactPersonID"] = new SelectList(_context.ContactPersons, "ContactPersonID", "ContactPersonID", fileContactPerson.ContactPersonID);
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId", fileContactPerson.FileID);
            return View(fileContactPerson);
        }

        // POST: FileContactPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FileContactPersonID,FileID,ContactPersonID")] FileContactPerson fileContactPerson)
        {
            if (id != fileContactPerson.FileContactPersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileContactPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileContactPersonExists(fileContactPerson.FileContactPersonID))
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
            ViewData["ContactPersonID"] = new SelectList(_context.ContactPersons, "ContactPersonID", "ContactPersonID", fileContactPerson.ContactPersonID);
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId", fileContactPerson.FileID);
            return View(fileContactPerson);
        }

        // GET: FileContactPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileContactPerson = await _context.FileContactPersons
                .Include(f => f.ContactPerson)
                .Include(f => f.File)
                .FirstOrDefaultAsync(m => m.FileContactPersonID == id);
            if (fileContactPerson == null)
            {
                return NotFound();
            }

            return View(fileContactPerson);
        }

        // POST: FileContactPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileContactPerson = await _context.FileContactPersons.FindAsync(id);
            _context.FileContactPersons.Remove(fileContactPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileContactPersonExists(int id)
        {
            return _context.FileContactPersons.Any(e => e.FileContactPersonID == id);
        }
    }
}
