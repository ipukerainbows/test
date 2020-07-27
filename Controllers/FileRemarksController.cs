using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AISV1.Data;
using AISV1.Models;

namespace AISV1.Controllers
{
    public class FileRemarksController : Controller
    {
        private readonly AISContext _context;

        public FileRemarksController(AISContext context)
        {
            _context = context;
        }

        // GET: FileRemarks
        public async Task<IActionResult> Index()
        {
            var aISContext = _context.FileRemarks.Include(f => f.File);
            return View(await aISContext.ToListAsync());
        }

        // GET: FileRemarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileRemark = await _context.FileRemarks
                .Include(f => f.File)
                .FirstOrDefaultAsync(m => m.FileRemarkID == id);
            if (fileRemark == null)
            {
                return NotFound();
            }

            return View(fileRemark);
        }

        // GET: FileRemarks/Create
        public IActionResult Create()
        {
            ViewData["FileID"] = new SelectList(_context.Files, "Id", "Id");
            return View();
        }

        // POST: FileRemarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FileRemarkID,FileID,Remark")] FileRemark fileRemark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileRemark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FileID"] = new SelectList(_context.Files, "Id", "Id", fileRemark.FileID);
            return View(fileRemark);
        }

        // GET: FileRemarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileRemark = await _context.FileRemarks.FindAsync(id);
            if (fileRemark == null)
            {
                return NotFound();
            }
            ViewData["FileID"] = new SelectList(_context.Files, "Id", "Id", fileRemark.FileID);
            return View(fileRemark);
        }

        // POST: FileRemarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FileRemarkID,FileID,Remark")] FileRemark fileRemark)
        {
            if (id != fileRemark.FileRemarkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileRemark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileRemarkExists(fileRemark.FileRemarkID))
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
            ViewData["FileID"] = new SelectList(_context.Files, "Id", "Id", fileRemark.FileID);
            return View(fileRemark);
        }

        // GET: FileRemarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileRemark = await _context.FileRemarks
                .Include(f => f.File)
                .FirstOrDefaultAsync(m => m.FileRemarkID == id);
            if (fileRemark == null)
            {
                return NotFound();
            }

            return View(fileRemark);
        }

        // POST: FileRemarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileRemark = await _context.FileRemarks.FindAsync(id);
            _context.FileRemarks.Remove(fileRemark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileRemarkExists(int id)
        {
            return _context.FileRemarks.Any(e => e.FileRemarkID == id);
        }
    }
}
