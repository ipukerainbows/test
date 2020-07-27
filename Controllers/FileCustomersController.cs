using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AISV1.Data;
using AISV1.Models;

namespace AISV2.Controllers
{
    public class FileCustomersController : Controller
    {
        private readonly AISContext _context;

        public FileCustomersController(AISContext context)
        {
            _context = context;
        }

        // GET: FileCustomers
        public async Task<IActionResult> Index()
        {
            var aISContext = _context.FileCustomers.Include(f => f.Customer).Include(f => f.File);
            return View(await aISContext.ToListAsync());
        }

        // GET: FileCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileCustomer = await _context.FileCustomers
                .Include(f => f.Customer)
                .Include(f => f.File)
                .FirstOrDefaultAsync(m => m.FileCustomerID == id);
            if (fileCustomer == null)
            {
                return NotFound();
            }

            return View(fileCustomer);
        }

        // GET: FileCustomers/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Name");
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId");
            return View();
        }

        // POST: FileCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FileCustomerID,Name,FileID,CustomerID")] FileCustomer fileCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", fileCustomer.CustomerID);
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId", fileCustomer.FileID);
            return View(fileCustomer);
        }

        // GET: FileCustomers/Create/1
        public IActionResult CreateFileID(int? id)
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Name");
            ViewData["FileID"] = id.ToString();
            return View();
        }

        // GET: FileCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileCustomer = await _context.FileCustomers.FindAsync(id);
            if (fileCustomer == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", fileCustomer.CustomerID);
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId", fileCustomer.FileID);
            return View(fileCustomer);
        }

        // POST: FileCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FileCustomerID,Name,FileID,CustomerID")] FileCustomer fileCustomer)
        {
            if (id != fileCustomer.FileCustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileCustomerExists(fileCustomer.FileCustomerID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", fileCustomer.CustomerID);
            ViewData["FileID"] = new SelectList(_context.Files, "FileId", "FileId", fileCustomer.FileID);
            return View(fileCustomer);
        }

        // GET: FileCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileCustomer = await _context.FileCustomers
                .Include(f => f.Customer)
                .Include(f => f.File)
                .FirstOrDefaultAsync(m => m.FileCustomerID == id);
            if (fileCustomer == null)
            {
                return NotFound();
            }

            return View(fileCustomer);
        }

        // POST: FileCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileCustomer = await _context.FileCustomers.FindAsync(id);
            _context.FileCustomers.Remove(fileCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileCustomerExists(int id)
        {
            return _context.FileCustomers.Any(e => e.FileCustomerID == id);
        }
    }
}
