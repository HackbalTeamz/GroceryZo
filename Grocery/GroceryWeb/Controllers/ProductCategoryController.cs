using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryBLL;

namespace GroceryWeb.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryBLL _productCategoryBLL;
        public ProductCategoryController(IProductCategoryBLL productCategoryBLL)
        {
            _productCategoryBLL = productCategoryBLL;

        }

        // GET: AdminTbls
        public IActionResult Index()
        {
            var gasNGoContext = _productCategoryBLL.GetAll();
            return View(gasNGoContext);
        }

        // GET: AdminTbls/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adminTbl = await _context.AdminTbls
        //        .Include(a => a.Cred)
        //        .FirstOrDefaultAsync(m => m.AdminId == id);
        //    if (adminTbl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(adminTbl);
        //}

        //// GET: AdminTbls/Create
        //public IActionResult Create()
        //{
        //    ViewData["CredId"] = new SelectList(_context.CredentialTbls, "CredId", "Email");
        //    return View();
        //}

        //// POST: AdminTbls/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AdminId,CredId,Name,EnteredOn,UpdatedOn")] AdminTbl adminTbl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(adminTbl);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CredId"] = new SelectList(_context.CredentialTbls, "CredId", "Email", adminTbl.CredId);
        //    return View(adminTbl);
        //}

        //// GET: AdminTbls/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adminTbl = await _context.AdminTbls.FindAsync(id);
        //    if (adminTbl == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CredId"] = new SelectList(_context.CredentialTbls, "CredId", "Email", adminTbl.CredId);
        //    return View(adminTbl);
        //}

        //// POST: AdminTbls/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("AdminId,CredId,Name,EnteredOn,UpdatedOn")] AdminTbl adminTbl)
        //{
        //    if (id != adminTbl.AdminId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(adminTbl);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdminTblExists(adminTbl.AdminId))
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
        //    ViewData["CredId"] = new SelectList(_context.CredentialTbls, "CredId", "Email", adminTbl.CredId);
        //    return View(adminTbl);
        //}

        //// GET: AdminTbls/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adminTbl = await _context.AdminTbls
        //        .Include(a => a.Cred)
        //        .FirstOrDefaultAsync(m => m.AdminId == id);
        //    if (adminTbl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(adminTbl);
        //}

        //// POST: AdminTbls/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var adminTbl = await _context.AdminTbls.FindAsync(id);
        //    _context.AdminTbls.Remove(adminTbl);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AdminTblExists(long id)
        //{
        //    return _context.AdminTbls.Any(e => e.AdminId == id);
        //}
    }
}
