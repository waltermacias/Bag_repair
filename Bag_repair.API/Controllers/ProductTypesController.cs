using Bag_repair.API.Data;
using Bag_repair.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Bag_repair.API.Controllers
{
     public class ProductTypesController : Controller
     {
          private readonly DataContext _context;

          public ProductTypesController(DataContext context)
          {
               _context = context;
          }

          // GET: ProductTypes
          public async Task<IActionResult> Index()
          {
               return View(await _context.ProductTypes.ToListAsync());
          }


          // GET: ProductTypes/Create
          public IActionResult Create()
          {
               return View();
          }

          // POST: ProductTypes/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create(ProductType productType)
          {
               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Add(productType);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El producto ya esta creado");
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

               return View(productType);
          }

          // GET: ProductTypes/Edit/5
          public async Task<IActionResult> Edit(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               ProductType productType = await _context.ProductTypes.FindAsync(id);
               if (productType == null)
               {
                    return NotFound();
               }
               return View(productType);
          }

          // POST: ProductTypes/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to.

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, ProductType productType)
          {
               if (id != productType.Id)
               {
                    return NotFound();
               }

               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Update(productType);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El producto ya esta creado");
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
               return View(productType);
          }

          // GET: ProductTypes/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               ProductType productType = await _context.ProductTypes
                .FirstOrDefaultAsync(m => m.Id == id);
               if (productType == null)
               {
                    return NotFound();
               }

               _context.ProductTypes.Remove(productType);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
          }
     }
}
