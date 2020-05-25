using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeledocTask.Data;
using TeledocTask.Models;

namespace TeledocTask.Controllers
{
    public class EntitiesController : Controller
    {
        private readonly ENTContext _context;




        public EntitiesController(ENTContext context)
        {
            _context = context;
        }

        public List<Entity> GetUL()
        {
            return _context.Entity.Where(e => e.EntType == EntType.UL).ToList();
        }


        public IActionResult CreateUCHR()
        {
            ViewBag.ULS = _context.Entity.Where(e => e.EntType == EntType.UL).ToList();
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateUCHR([Bind("Title,INN,EntType,ParentEntity")] UCHCreationModel model)
        {
            if (ModelState.IsValid)
            {
                Entity entity = new Entity();
                entity.CrDate = entity.ChDate = DateTime.Now;
                entity.Title = model.Title;
                entity.INN = model.INN;
                entity.EntType = model.EntType;
                entity.ParentEntity = _context.Entity.Where(e => e.ID == model.ParentEntity).FirstOrDefault();
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Entities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entity.ToListAsync());
        }

        // GET: Entities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Entity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Entities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,INN,EntType")] Entity entity)
        {
            if (ModelState.IsValid)
            {
                entity.CrDate = entity.ChDate = DateTime.Now;
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: Entities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Entity.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: Entities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,INN,CrDate,EntType")] Entity entity)
        {
            if (id != entity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    entity.ChDate = DateTime.Now;
                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entity.ID))
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
            return View(entity);
        }

        // GET: Entities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Entity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: Entities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.Entity.FindAsync(id);
            var entites = _context.Entity.Where(e => e.ParentEntity == entity).ToList();
            if (entites.Count > 0)
            {
                foreach (var el in entites)
                {
                    el.ParentEntity = null;
                    el.ChDate = DateTime.Now;
                    _context.Update(el);
                }
            }
            _context.Entity.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityExists(int id)
        {
            return _context.Entity.Any(e => e.ID == id);
        }
    }

}
