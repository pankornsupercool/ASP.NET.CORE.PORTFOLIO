using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET.CRUD.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET.CRUD.Controllers
{
    [Authorize]
    public class TodolistController : Controller
    {
        
        private readonly TodolistContext _context;

        public TodolistController(TodolistContext context)
        {
            _context = context;
        } 

        // GET: Todolist
        public async Task<IActionResult> Index()
        {
            return View(await _context.Todolists.ToListAsync());
        }

        public async Task<IActionResult> Todolist()
        {
            return View();
        }
        //// GET: Todolist/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var todolist = await _context.Todolists
        //        .FirstOrDefaultAsync(m => m.TodolistId == id);
        //    if (todolist == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(todolist);
        //}

        // GET: Todolist/Create 
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Todolist());
            }
            else
            {
                return View(_context.Todolists.Find(id));
            }

            

        }

        // POST: Todolist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TodolistId,Title,Content,Period")] Todolist todolist)
        {
            if (ModelState.IsValid)
            {
                if (todolist.TodolistId == 0)
                {
                    _context.Add(todolist);
                }
                else
                {
                    _context.Update(todolist);
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todolist);
        }

        //// GET: Todolist/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var todolist = await _context.Todolists.FindAsync(id);
        //    if (todolist == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(todolist);
        //}

        //// POST: Todolist/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("TodolistId,Title,Content,Period")] Todolist todolist)
        //{
        //    if (id != todolist.TodolistId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(todolist);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TodolistExists(todolist.TodolistId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(todolist);
        //}

        // GET: Todolist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var todolist =await _context.Todolists.FindAsync(id);
            _context.Todolists.Remove(todolist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var todolist = await _context.Todolists
            //    .FirstOrDefaultAsync(m => m.TodolistId == id);
            //if (todolist == null)
            //{
            //    return NotFound();
            //}

            //return View(todolist);
        }

        //// POST: Todolist/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var todolist = await _context.Todolists.FindAsync(id);
        //    _context.Todolists.Remove(todolist);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TodolistExists(int id)
        {
            return _context.Todolists.Any(e => e.TodolistId == id);
        }
    }
}
