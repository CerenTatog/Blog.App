using Blog.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserManager _userManager;

        public UserProfileController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Herkese açık.
        //Kullanıcının yayınladığı makaleler(tag,başlık, content max.100 karakter)(sağ taraf)
        //Sol atarf kullanıcı resmi ,hakkında bilgisi
        public IActionResult Profile()
        {
            return View();
        }

		public IActionResult SelectTagList()
		{
			return View();

		}

		//Kullanıcı için
		//Kullanıcının yayınladığı makaleler(tag,başlık, content max.100 karakter)(sağ taraf)
		//Sol taraf kullanıcı resmi ,hakkında bilgisi
		public IActionResult UserMainPage() 
        {
            return View();
        
        }
        //emailadress username-subdomain, profil bilgisi, profile design alanları deleted account ayarlaru
        
        public IActionResult EditProfile() 
        {
            return View();

        }

        //ViewComponent şeklinde sağ tarafta yazarın Profil resmi, ismi, kaç takipçisi, kısa açıklama ve follow/mesaj atma alanları yer alacak. 
        public IActionResult ProfileComponent() 
        {
            return View();
        
        }

        //En çok yazı yazan top writerlar.
        //View Component olarak gelecek.
        public IActionResult TopWriters()
        {
            return View();
        }
    }
}
