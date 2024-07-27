using dotnetMastery.Data;
using dotnetMastery.Models;
using Microsoft.AspNetCore.Mvc;


namespace dotnetMastery.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","Name and Display Order cannot be same"); //accepts key and error message, key here is the "asp-for" tag helper in create.html
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //accepts action name if in same controller or else action name and controller name are param
            }
            return View();
            
        }

         public IActionResult Edit(int? id)
        
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            Category? CategoryFromDb = _db.Categories.Find(id);
            //Category? CategoryFromDb1 = _db.Categories.Where(u=>u.CategoryId == id).FirstOrDefault();
            //Category? CategoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.CategoryId == id);             //Anny of the three can be used to get data from db but Find()is used only for primary key's
            if(CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","Name and Display Order cannot be same"); //accepts key and error message, key here is the "asp-for" tag helper in create.html
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //accepts action name if in same controller or else action name and controller name are param
            }
            return View();
            
        }
    }
}