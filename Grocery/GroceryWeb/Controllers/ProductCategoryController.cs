using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryBLL;
using GroceryBOL;
using System;

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
        public IActionResult Create()
        {
            return View();
        }

        //// POST: AdminTbls/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategoryDTO productCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                _productCategoryBLL.Add(productCategoryDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productCategoryDTO);
        }

        //// GET: AdminTbls/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminTbl = _productCategoryBLL.GetById(id);
            if (adminTbl == null)
            {
                return NotFound();
            }
            return View(adminTbl);
        }

        //// POST: AdminTbls/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ProductCategoryDTO productCategoryDTO)
        {
            if (id != productCategoryDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productCategoryBLL.Update(productCategoryDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productCategoryDTO);
        }

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
