using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class CategoriesController : Controller
	{
		public IActionResult Index()
		{
			var categories = CategoriesRepository.GetCategories();
			return View(categories);
		}
		public IActionResult Edit(int? id) // default value of id is 0
		{
			/*if(id.HasValue)
			{
				return new ContentResult { Content = id.ToString() };
			}
			else
			{
				return new ContentResult { Content = "null content" };
			}*/

			// combine model with view
			ViewBag.Action = "edit";
			var category =  CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if(ModelState.IsValid)
			{
				CategoriesRepository.UpdateCategory(category.CategoryId, category);
				return RedirectToAction(nameof(Index));

			}
			return View(category);
		}
		public IActionResult Add()
		{
			ViewBag.Action = "add";
			return View();
		}

		[HttpPost]
		public IActionResult Add(Category category)
		{
			if(ModelState.IsValid)
			{
				CategoriesRepository.AddCategory(category);
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		public IActionResult Delete(int categoryId)
		{
			CategoriesRepository.DeleteCategory(categoryId);
			return RedirectToAction(nameof(Index));
		}
	}
}