using BlogSite.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class ArticleAdminController : Controller
    {
        ArticleManager repoArticle = new ArticleManager();

        public ActionResult Index()

        {

            var model = repoArticle.List();
            return View(model);
        }
        public ActionResult Delete(int Id)
        
        {
            var model = repoArticle.GeyById(Id);
            repoArticle.Delete(model);
            return RedirectToAction("Index");
        }
    }
}