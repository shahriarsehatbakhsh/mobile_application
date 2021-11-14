using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class ModelCController : Controller
    {
        private readonly testContext _context;

        public ModelCController(testContext context)
        {
            _context = context;
        }

        // GET: ModelC
        public async Task<IActionResult> Index()
        {
            return View(await _context.Model1.ToListAsync());
        }

        // GET: ModelC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model1 = await _context.Model1
                .FirstOrDefaultAsync(m => m.Code == id);
            if (model1 == null)
            {
                return NotFound();
            }

            return View(model1);
        }

        // GET: ModelC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Sharh")] Model1 model1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model1);
        }

        // GET: ModelC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model1 = await _context.Model1.FindAsync(id);
            if (model1 == null)
            {
                return NotFound();
            }
            return View(model1);
        }

        // POST: ModelC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Sharh")] Model1 model1)
        {
            if (id != model1.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Model1Exists(model1.Code))
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
            return View(model1);
        }

        // GET: ModelC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model1 = await _context.Model1
                .FirstOrDefaultAsync(m => m.Code == id);
            if (model1 == null)
            {
                return NotFound();
            }

            return View(model1);
        }

        // POST: ModelC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model1 = await _context.Model1.FindAsync(id);
            _context.Model1.Remove(model1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Model1Exists(int id)
        {
            return _context.Model1.Any(e => e.Code == id);
        }
    }
}
