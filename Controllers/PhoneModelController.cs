using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class PhoneModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhoneModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhoneModel
        public async Task<IActionResult> Index()
        {
              return _context.PhoneModels != null ? 
                          View(await _context.PhoneModels.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PhoneModels'  is null.");
        }

        // GET: PhoneModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhoneModels == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (phoneModel == null)
            {
                return NotFound();
            }

            return View(phoneModel);
        }

        // GET: PhoneModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ModelName")] PhoneModel phoneModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneModel);
        }

        // GET: PhoneModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhoneModels == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModels.FindAsync(id);
            if (phoneModel == null)
            {
                return NotFound();
            }
            return View(phoneModel);
        }

        // POST: PhoneModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ModelName")] PhoneModel phoneModel)
        {
            if (id != phoneModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneModelExists(phoneModel.id))
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
            return View(phoneModel);
        }

        // GET: PhoneModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhoneModels == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (phoneModel == null)
            {
                return NotFound();
            }

            return View(phoneModel);
        }

        // POST: PhoneModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhoneModels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PhoneModels'  is null.");
            }
            var phoneModel = await _context.PhoneModels.FindAsync(id);
            if (phoneModel != null)
            {
                _context.PhoneModels.Remove(phoneModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneModelExists(int id)
        {
          return (_context.PhoneModels?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
