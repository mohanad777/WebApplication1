using ClassLibrary1.DataAccess.Repoistory.IRepoistory;
using ClassLibrary1.Models;
using ClassLibrary1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUniteOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUniteOfWork db, IWebHostEnvironment webHostEnvironment) {
            
            _db = db; 
            _webHostEnvironment = webHostEnvironment;   
             
        
        }

        public IActionResult Index()
        {

            List<Product> products = _db.product.GetAll(includeProperties: "Category").ToList();
            IEnumerable<SelectListItem> categoryList=_db.category.GetAll().Select(
                u=>new SelectListItem
                {
                    Text = u.Name,
                    Value=u.ID.ToString()
                }
                );
            return View(products);
           
        }

        public IActionResult Create(int ? id)
        {
            ProductVM productVM = new ProductVM()
            {
                CategoryList = _db.category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _db.product.Get(u => u.Id == id);
                if (productVM.Product == null)
                {
                    return NotFound();
                }


                return View(productVM);

            }
            

        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM, IFormFile? file)
        {


            //  _db.categories.Add(ct);
            //  _db.SaveChanges();
 

            string wwwrootBath = _webHostEnvironment.WebRootPath;

            if (file != null)
                {

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string ProductPath = Path.Combine(wwwrootBath, @"images\product");
                productVM.Product.ImageUrl = @"images\product\" + fileName;

                using (var fileStream=new FileStream(Path.Combine(ProductPath,fileName),FileMode.Create)) {
                    
                    file.CopyTo(fileStream);
                    }


                
                        _db.product.Add(productVM.Product);
                          _db.save();
                }
                
            
    
            TempData["success"] = "Product successfully Created";
            return RedirectToAction("Index");


        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Category category = _db.categories.Find(id);
            Product product = _db.product.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
 

            return View(product);

        }
        [HttpPost]
        public IActionResult Edit(Product product)

        {

            if (ModelState.IsValid)
            {
                //  _db.categories.Update(category);
                //   _db.SaveChanges();
                _db.product .update(product);
                _db.save();
                TempData["success"] = "product successfully udpated";
                return RedirectToAction(nameof(Index)); // Assuming 'Index' is your action method to list categories
            }
            return View(product);

        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = _db.product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = products });
        }
       
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Category category = _db.categories.Find(id);
            Product product = _db.product.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _db.product.Delete(product);
            _db.save();

            return Json(new {success=true, message="Delete Successfully"});

        }  
        #endregion
    }  
}
