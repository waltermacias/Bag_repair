using Bag_repair.API.Data;
using Bag_repair.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Bag_repair.API.Controllers
{
     public class CataloguesController : Controller
     {
          private readonly DataContext _context;

          public CataloguesController(DataContext context)
          {
               _context = context;
          }

          // GET: Catalogues
          public async Task<IActionResult> Index()
          {
               return View(await _context.Catalogues.ToListAsync());
          }


          // GET: Catalogues/Create
          public IActionResult Create()
          {
               return View();
          }

          // POST: Catalogues/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create(Catalogue catalogue)
          {
               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Add(catalogue);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El Producto de catalogo ya esta creado");
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

               return View(catalogue);
          }

          // GET: Catalogues/Edit/5
          public async Task<IActionResult> Edit(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               Catalogue catalogue = await _context.Catalogues.FindAsync(id);
               if (catalogue == null)
               {
                    return NotFound();
               }
               return View(catalogue);
          }

          // POST: Catalogues/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to.

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, Catalogue catalogue)
          {
               if (id != catalogue.Id)
               {
                    return NotFound();
               }

               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Update(catalogue);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El Producto de Catalogo ya esta creado");
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
               return View(catalogue);
          }

          // GET: Catalogues/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               Catalogue catalogue = await _context.Catalogues
                .FirstOrDefaultAsync(m => m.Id == id);
               if (catalogue == null)
               {
                    return NotFound();
               }

               _context.Catalogues.Remove(catalogue);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
          }
     }
}

