using InventoryMVCCoreWeb.Models;
using InventoryMVCCoreWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryMVCCoreWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly InventoryService _inventoryService;

        public ProductController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var model = await _inventoryService.GetInventoryProductsAsync();
            return View(model);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await _inventoryService.GetInventoryProductByIdAsync(id);
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Logic to create a new product would go here
                    await _inventoryService.AddInventoryProductAsync(dto);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _inventoryService.GetInventoryProductByIdAsync(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductViewModel dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Logic to update the product would go here
                    await _inventoryService.UpdateInventoryProductAsync(dto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _inventoryService.GetInventoryProductByIdAsync(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductViewModel dto)
        {
            try
            {
                // Logic to delete the product would go here
                await _inventoryService.DeleteInventoryProductAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
