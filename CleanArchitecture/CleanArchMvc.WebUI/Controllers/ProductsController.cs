using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _iProductService;
        private readonly ICategoryService _iCategoryService;
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        public ProductsController(IProductService iProductService, ICategoryService iCategoryService, IWebHostEnvironment iWebHostEnvironment)
        {
            _iProductService = iProductService;
            _iCategoryService = iCategoryService;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        #region Verbo GET

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var returnResult = await _iProductService.GetProducts();
            return View(returnResult);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _iCategoryService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id == 0)
                return NotFound();

            var returnResult = await _iProductService.GetById(id);
            var returnResultCategories = await _iCategoryService.GetCategories();

            if (returnResult == null || returnResultCategories == null)
                return NotFound();

            ViewBag.CategoryId = new SelectList(returnResultCategories, "Id", "Name");

            return View(returnResult);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id = 0)
        {
            if (id == 0)
                return NotFound();

            var returnResult = await _iProductService.GetById(id);

            if (returnResult == null)
                return NotFound();

            return View(returnResult);
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int id = 0)
        {
            if (id == 0)
                return NotFound();

            var returnResult = await _iProductService.GetById(id);
            if(returnResult == null)
                return NotFound();

            var wwwroot = _iWebHostEnvironment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + returnResult.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(returnResult);
        }

        #endregion Verbo GET

        #region Verbo POST

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _iProductService.Add(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _iProductService.Update(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id = 0)
        {
            await _iProductService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion Verbo POST
    }
}