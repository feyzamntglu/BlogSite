using BlogSite.BussinessLayer;
using BlogSite.BussinessLayer.Abstract;
using BlogSite.DataEntities;
using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        // Repository<Article> repoArticle = new Repository<Article>();
        // Repository<Author> repoAuthor = new Repository<Author>();

        ArticleManager repoArticle = new ArticleManager();
        AuthorManager repoAuthor = new AuthorManager();

        public ActionResult Index()
        {
            //Test test = new Test();

            var articleList = repoArticle.List();
            ViewBag.Keywords = "seyehat eğlence alışveriş blog site";
            ViewBag.Description = "2019 yılından beri";
            ViewBag.Title = "Blog Site | Anasayfa";

            return View(articleList);
        }

        public ActionResult Authors()
        {

            var articleList = repoArticle.List();
            var authorList = articleList.GroupBy(u => new { u.Author }).Select(grp => grp.FirstOrDefault()).ToList();
            ViewBag.AuthorList = authorList.ToList();
            return View();
        }

        public ActionResult Detail(string linkUrl)
        {

            if (linkUrl == null)
            {
                return RedirectToAction("","");
            }
            ViewBag.Title = "Makale |Detay sayfası";
            var articleModel = (from article in repoArticle.List()
                                             join author in repoAuthor.List() on article.Author equals author.NameSurname
                                             where article.ArticleUrl == linkUrl
                                             select new ArticleViewModel
                                             {
                                                 //Article
                                                 ArticleId = article.Id,
                                                 ArticleUrl = article.ArticleUrl,
                                                 ArticleCategory = article.CategoryName,
                                                 ArticleDate = article.ArticleDate,
                                                 ArticleReading=article.ReadingCount,
                                                 ArticleTags = article.Tags.Split(','),
                                                 Title=article.Title,
                                                 Content=article.Content,
                                                 //Author
                                                AuthorAbout = author.AuthorAbout,
                                                AuthorFacebook  = author.FacebookAdress,
                                                AuthorImageUrl  = author.Image,
                                                AuthorInstagram = author.InstagramAdress,
                                                AuthorName      = author.NameSurname,
                                                AuthorTwitter   = author.TwitterAdress,




                                             }).FirstOrDefault();


            return View(articleModel);
        }

        public ActionResult TopArticle()
        {
            var articleList = repoArticle.List().Take(2).OrderByDescending(m => m.ReadingCount).Take(3).ToList();
            return View(articleList);
        }

        public ActionResult InstagramArea()
        {
            
            return View();
        }

        public ActionResult Advertisement()
        {

            return View();
        }

        public ActionResult Create()
        {
            Article article = new Article()
            {

                ArticleDate = "10 şubat 2018",
                Author = "Önceki Yazılımcı",
                ReadingCount = 50,
                CategoryName = "seyahat",
                Content = "Malatyanın güneydoğusunda kalan Battalgazi'nin Kervansarayı,günümüze taşıdığı tarihi değerleriyle bize bilgi veriyor.",
                ImageUrl = "/Content/img/blog/2.jpg",
                IsActive = true,
                Tags = "Seyahat,Eğlence,Alışveriş,Yazılım",
                ArticleUrl = "urfa'nin-sakli-cenneti-harran-ovasi",
                Title = "Seyahat etmenin faydaları"

            };


            repoArticle.Insert(article);
            return View();

        }

    }
}
