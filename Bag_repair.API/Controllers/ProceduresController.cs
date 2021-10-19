using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Bag_repair.API.Data;
using Bag_repair.API.Data.Entities;

namespace Bag_repair.API.Controllers
{
     public class ProceduresController : Controller
     {
          private readonly DataContext _context;

          public ProceduresController(DataContext context)
          {
               _context = context;
          }

          // GET: Procedure
          public async Task<IActionResult> Index()
          {
               return View(await _context.Procedures.ToListAsync());
          }


          // GET: Procedure/Create
          public IActionResult Create()
          {
               return View();
          }

          // POST: Procedure/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create(Procedure procedure)
          {
               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Add(procedure);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El procedimiento ya esta creado");
                         }
                         else
                         {
                              ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                         }
                    }
                    catch (Exception exeption)
                    {
                         ModelState.AddModelError(string.Empty, exeption.Message);
                    }
               }

               return View(procedure);
          }

          // GET: Procedure/Edit/5
          public async Task<IActionResult> Edit(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               Procedure procedure = await _context.Procedures.FindAsync(id);
               if (procedure == null)
               {
                    return NotFound();
               }
               return View(procedure);
          }

          // POST: Procedure/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to.

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, Procedure procedure)
          {
               if (id != procedure.Id)
               {
                    return NotFound();
               }

               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Update(procedure);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El Procedimiento ya esta creado");
                         }
                         else
                         {
                              ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                         }
                    }
                    catch (Exception exeption)
                    {
                         ModelState.AddModelError(string.Empty, exeption.Message);
                    }
               }
               return View(procedure);
          }

          // GET: Procedure/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               Procedure procedure = await _context.Procedures
                .FirstOrDefaultAsync(m => m.Id == id);
               if (procedure == null)
               {
                    return NotFound();
               }

               _context.Procedures.Remove(procedure);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
          }
     }
}

