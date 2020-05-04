using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dip.web.Data;
using dip.web.Data.Entities;

namespace dip.web.Controllers
{
    public class DipsController : Controller
    {
        private readonly DataContext _context;

        public DipsController(DataContext context)
        {
            _context = context;
        }

        // GET: Dips
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dips.ToListAsync());
        }

        // GET: Dips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipEntity = await _context.Dips
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dipEntity == null)
            {
                return NotFound();
            }

            return View(dipEntity);
        }

        // GET: Dips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DipEntity dipEntity)
        {
            if (ModelState.IsValid)
            {
                dipEntity.Plaque = dipEntity.Plaque.ToUpper();
                _context.Add(dipEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dipEntity);
        }

        // GET: Dips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipEntity = await _context.Dips.FindAsync(id);
            if (dipEntity == null)
            {
                return NotFound();
            }
            return View(dipEntity);
        }

        // POST: Dips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DipEntity dipEntity)
        {
            if (id != dipEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dipEntity.Plaque = dipEntity.Plaque.ToUpper();
                _context.Update(dipEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dipEntity);
        }

        // GET: Dips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipEntity = await _context.Dips
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dipEntity == null)
            {
                return NotFound();
            }


            _context.Dips.Remove(dipEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        
    }
}
