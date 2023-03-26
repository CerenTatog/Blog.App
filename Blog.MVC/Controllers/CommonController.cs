using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class CommonController : Controller
    {//bu kısım üye olmadan görünen ana sayfayı temsil eder.
        //Ana sayfada, hakkımızda, write, sign in ve get started menüsü var. =>herkese açık
        //1.TrendingOnForeSight
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult TrendingArticles() 
        {
            //main page içindeki analiste
            return View();
        }

        public IActionResult MostReadArticles()
        {
            //mainpage içindeki analiste
            return View();
        }

        

        public IActionResult ArticleByTag()
        {
            //seçilen etikete göre ilgili makalelerin listelendiği sayfa.
            //Follow ya da start writing diyebilmek için giriş yapmak gerekli.
            //Trending,latest ve best opsiyonları içerebilir. 
            return View();
        }

        //viewComponent
        //Kullancının takip etmediği tagler burada yer alacak.
        public IActionResult UnFollowTagLists() 
        {
            return View();
        
        }

        
    }
}
