using Bag_repair.API.Data;
using Bag_repair.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Bag_repair.API.Controllers
{
     public class DocumentTypesController : Controller
     {
          private readonly DataContext _context;
          public DocumentTypesController(DataContext context)
          {
               _context = context;
          }
          // GET: DocumentTypes
          public async Task<IActionResult> Index()
          {
               return View(await _context.DocumentTypes.ToListAsync());
          }


          // GET: DocumentTypes/Create
          public IActionResult Create()
          {
               return View();
          }

          // POST: DocumentTypes/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create(DocumentType documentType)
          {
               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Add(documentType);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El documento ya esta creado");
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

               return View(documentType);
          }

          // GET: DocumentTypes/Edit/5
          public async Task<IActionResult> Edit(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               DocumentType documentType = await _context.DocumentTypes.FindAsync(id);
               if (documentType == null)
               {
                    return NotFound();
               }
               return View(documentType);
          }

          // POST: DocumentTypes/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to.

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, DocumentType documentType)
          {
               if (id != documentType.Id)
               {
                    return NotFound();
               }

               if (ModelState.IsValid)
               {
                    try
                    {
                         _context.Update(documentType);
                         await _context.SaveChangesAsync();
                         return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                         if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                         {
                              ModelState.AddModelError(string.Empty, "El documento ya esta creado");
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
               return View(documentType);
          }

          // GET: documentType/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               DocumentType documentType = await _context.DocumentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
               if (documentType == null)
               {
                    return NotFound();
               }

               _context.DocumentTypes.Remove(documentType);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
          }
     }
}
