using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Verbo GET

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var returnResult = await _categoryService.GetCategories();
            return View(returnResult);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id == 0)
                return BadRequest();

            var returnResult = await _categoryService.GetById(id);

            if (returnResult == null)
                return NotFound();

            return View(returnResult);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id = 0)
        {
            if (id == 0)
                return NotFound();

            var returnResult = await _categoryService.GetById(id);

            if (returnResult == null)
                return NotFound();

            return View(returnResult);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id = 0)
        {
            if (id == 0)
                return NotFound();

            var returnResult = await _categoryService.GetById(id);

            if (returnResult == null)
                return NotFound();

            return View(returnResult);
        }

        #endregion Verbo GET

        #region Verbo POST

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(categoryDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id = 0)
        {
            await _categoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion Verbo POST
    }
}