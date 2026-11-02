using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using BE5_CustomerSite.Models;
using BE5_CustomerSite.Models.ViewModel;
using PagedList;

namespace BE5_CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyStoreEntities db = new MyStoreEntities();
        private const int HomePageSize = 6;
        private const int DetailTopPageSize = 3;

        public ActionResult Index(string searchTerm, int? page)
        {
            var products = db.Products.Include(p => p.Category).AsQueryable();

            if (!String.IsNullOrWhiteSpace(searchTerm))
            {
                string keyword = searchTerm.Trim();
                products = products.Where(p =>
                    p.ProductName.Contains(keyword) ||
                    p.ProductDescription.Contains(keyword) ||
                    p.Category.CategoryName.Contains(keyword));
            }

            var soldQuery = db.OrderDetails.GroupBy(x => x.ProductID)
                .Select(g => new { ProductID = g.Key, Sold = g.Sum(x => x.Quantity) });

            var featured = products
                .OrderByDescending(p => soldQuery
                    .Where(s => s.ProductID == p.ProductID)
                    .Select(s => (int?)s.Sold).FirstOrDefault() ?? 0)
                .Take(10).ToList();

            foreach (var item in featured)
            {
                item.SoldQuantity = db.OrderDetails.Where(x => x.ProductID == item.ProductID)
                    .Select(x => (int?)x.Quantity).DefaultIfEmpty(0).Sum() ?? 0;
            }

            var newest = products
                .OrderBy(p => soldQuery.Where(s => s.ProductID == p.ProductID)
                    .Select(s => (int?)s.Sold).FirstOrDefault() ?? 0)
                .ThenByDescending(p => p.ProductID)
                .Take(20)
                .ToPagedList(page ?? 1, HomePageSize);

            var model = new HomeProductVM
            {
                FeaturedProducts = featured,
                NewProducts = newest,
                SearchTerm = searchTerm
            };
            ViewBag.Categories = db.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(model);
        }

        public ActionResult ProductList(int? id, int? page)
        {
            if (id == null) return RedirectToAction("Index");
            var category = db.Categories.Find(id);
            if (category == null) return HttpNotFound();

            var products = db.Products.Include(p => p.Category)
                .Where(p => p.CategoryID == id.Value)
                .OrderByDescending(p => p.ProductID)
                .ToPagedList(page ?? 1, HomePageSize);

            ViewBag.CategoryName = category.CategoryName;
            ViewBag.Categories = db.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult ProductDetail(int? id, int quantity = 1, int page = 1)
        {
            if (id == null) return RedirectToAction("Index");
            var product = db.Products.Include(p => p.Category)
                .FirstOrDefault(p => p.ProductID == id.Value);
            if (product == null) return HttpNotFound();

            product.SoldQuantity = db.OrderDetails.Where(x => x.ProductID == product.ProductID)
                .Select(x => (int?)x.Quantity).DefaultIfEmpty(0).Sum() ?? 0;

            var soldByProduct = db.OrderDetails.GroupBy(x => x.ProductID)
                .Select(g => new { ProductID = g.Key, Sold = g.Sum(x => x.Quantity) });

            var related = db.Products.Include(p => p.Category)
                .Where(p => p.CategoryID == product.CategoryID && p.ProductID != product.ProductID)
                .OrderByDescending(p => p.ProductID).Take(8).ToList();

            var top = db.Products.Include(p => p.Category)
                .Where(p => p.CategoryID == product.CategoryID)
                .OrderByDescending(p => soldByProduct
                    .Where(s => s.ProductID == p.ProductID)
                    .Select(s => (int?)s.Sold).FirstOrDefault() ?? 0)
                .Take(8).ToList();

            foreach (var item in related.Concat(top))
                item.SoldQuantity = db.OrderDetails.Where(x => x.ProductID == item.ProductID)
                    .Select(x => (int?)x.Quantity).DefaultIfEmpty(0).Sum() ?? 0;

            var model = new ProductDetailVM
            {
                Product = product,
                RelatedProducts = related,
                TopProducts = top,
                Quantity = Math.Max(1, quantity),
                Page = Math.Max(1, page)
            };
            ViewBag.Categories = db.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDetail(int id, int quantity)
        {
            if (quantity < 1) quantity = 1;
            var product = db.Products.Find(id);
            if (product == null) return HttpNotFound();

            var cart = Session["Cart"] as System.Collections.Generic.Dictionary<int, int>;
            if (cart == null)
                cart = new System.Collections.Generic.Dictionary<int, int>();

            if (cart.ContainsKey(id)) cart[id] += quantity;
            else cart.Add(id, quantity);

            Session["Cart"] = cart;
            TempData["CartMessage"] = "Đã thêm sản phẩm vào giỏ hàng.";
            return RedirectToAction("ProductDetail", new { id = id, quantity = quantity });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
