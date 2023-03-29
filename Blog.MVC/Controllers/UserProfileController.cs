using Blog.BLL;
using Blog.BLL.Concrete;
using Blog.BLL.Helper;
using Blog.Model.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserManager _userManager;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public UserProfileController(IUserManager userManager,IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Herkese açık.
        //Kullanıcının yayınladığı makaleler(tag,başlık, content max.100 karakter)(sağ taraf)
        //Sol atarf kullanıcı resmi ,hakkında bilgisi
        public IActionResult Profile(string authorUrl)
        {
            var model = _userManager.GetProfile(authorUrl);
            return View(model);
        }



        public IActionResult SelectTagList()
        {
            return View();

        }


        //emailadress username-subdomain, profil bilgisi, profile design alanları deleted account ayarlaru

        public IActionResult EditProfile(UserViewModel model)
        {
            if (model != null)
            {
				return View(model);
			}
            return NotFound();

        }
        //usermanager'a bakılması gerekiyor.
        [HttpPost]
		public IActionResult EditProfile(IFormFile file, string data)
		{
			string ext = Path.GetExtension(file.FileName);
            string resimAd = Guid.NewGuid() + ext;
			string dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", resimAd);
			using (var stream = new FileStream(dosyaYolu, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			UserViewModel formData = JsonConvert.DeserializeObject<UserViewModel>(data);
			
			var result = _userManager.ProfileAddOrUpdate(new UserViewModel()
			{
				UserName = formData.UserName,
                Email= formData.Email,
                PictureUrl= formData.PictureUrl,
                ProfileDescription=formData.ProfileDescription,
                UserURL= formData.Email.GetUserURLByMail(),
			});
			return Json(result);

		}


		public IActionResult DeleteProfile(int id) 
        {
            return View();
        
        }




    }
}
