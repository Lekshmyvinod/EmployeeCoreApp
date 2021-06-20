using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeCoreApp.Data;
using EmployeeCoreApp.Models;

namespace EmployeeCoreApp.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _adb;

        public ApplicationTypeController(ApplicationDbContext context)
        {
            _adb = context;
        }

        // GET: ApplicationType
        public async Task<IActionResult> Index()
        {
            return View(await _adb.ApplicationType.ToListAsync());
        }

        // GET: ApplicationType/Details/5
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ApplicationType = await _adb.ApplicationType
                .FirstOrDefaultAsync(m => m.ID == ID);
            if (ApplicationType == null)
            {
                return NotFound();
            }

            return View(ApplicationType);
        }

        // GET: ApplicationType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ApplicationType ApplicationType)
        {
            if (ModelState.IsValid)
            {
                _adb.Add(ApplicationType);
                await _adb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ApplicationType);
        }

        // GET: ApplicationType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationType = await _adb.ApplicationType.FindAsync(id);
            if (ApplicationType == null)
            {
                return NotFound();
            }
            return View(ApplicationType);
        }

        // POST: ApplicationType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ID, [Bind("ID,Name")] ApplicationType ApplicationType)
        {
            if (ID != ApplicationType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _adb.Update(ApplicationType);
                    await _adb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationTypeExists(ApplicationType.ID))
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
            return View(ApplicationType);
        }

        private bool ApplicationTypeExists(int? ID)
        {
            throw new NotImplementedException();
        }

        // GET: ApplicationType/Delete/5
        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ApplicationType = await _adb.ApplicationType
                .FirstOrDefaultAsync(m => m.ID == ID);
            if (ApplicationType == null)
            {
                return NotFound();
            }

            return View(ApplicationType);
        }

        // POST: ApplicationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            var ApplicationType = await _adb.ApplicationType.FindAsync(ID);
            _adb.ApplicationType.Remove(ApplicationType);
            await _adb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationTypeExists(int ID)
        {
            return _adb.ApplicationType.Any(e => e.ID == ID);
        }
    }
}