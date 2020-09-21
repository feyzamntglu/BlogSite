using BlogSite.BussinessLayer;
using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class CategoryController : Controller
    {
        ArticleManager repoArticle = new ArticleManager();
        // GET: Category
        public ActionResult Index(string CategoryName) 
        {
            if (CategoryName==null)
            {
                return RedirectToAction("",""); //Anasayfayı dönderiyor
            }
            ViewBag.Title = "BlogSite | " + CategoryName;
            List<ArticleByCategory> _articleByCategory;
            _articleByCategory = (from article in repoArticle.List()
                                  where CategoryName == Utils.UrlDuzenleme.UrlCevir(article.CategoryName).ToLower()
                                  select new ArticleByCategory
                                  {
                                      ArticleCategory=article.CategoryName,
                                      ArticleDate=article.ArticleDate,
                                      ArticleReading= article.ReadingCount,
                                      ArticleUrl=article.ArticleUrl,
                                      AuthorName=article.Author,
                                      Content=article.Content,
                                      Title=article.Title,
                                      ImageUrl=article.ImageUrl
                                  
                                  }).ToList();
                              
            
            

            return View(_articleByCategory);
        }
    }
}