﻿using Blog.BLL;
using Blog.BLL.Concrete;
using Blog.BLL.Helper;
using Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blog.MVC.Controllers
{
    public class AccountController : Controller
    {
        private IAccountManager _accountManager;
        private IArticleManager _articleManager;
        public AccountController(IAccountManager accountManager, IArticleManager articleManager)
        {
            _accountManager = accountManager;
            _articleManager = articleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Register()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserRegisterViewModel model)
        {
            var result = _accountManager.Register(model);
            return Json(result);
        }

		
		public IActionResult ActivatedMail(string guid)
		{
			var result = _accountManager.ActivatedMail(guid);
            if (result.State != Model.Models.ServiceResultState.SUCCESS)
            {
				return View(new ActivatedMailResponseViewModel());
			}
			return View(result.Result);
		}

		public IActionResult SignInMail(string guid)
		{
			var result = _accountManager.SignInMail(guid);
			if (result.State != Model.Models.ServiceResultState.SUCCESS)
			{
				return View();
			}
			return RedirectToAction("Index","Home");
		}

		
		public IActionResult SignIn()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public IActionResult SignInUser([FromBody] UserRegisterViewModel model)
        {
            var result = _accountManager.SignIn(model);
            return Json(result);
        }

        
        public IActionResult SignUp()
        {
            return View(new UserRegisterViewModel());
        }

        public IActionResult SelectedTag()
        {
			var tagList = _articleManager.GetAllTags().Select(x => new SelectListItem()
			{
				Selected = false,
				Text = x.TagName,
				Value = x.TagId.ToString()

			}).ToList();
			
			return View(tagList);
			
        }

		[HttpPost]
		public IActionResult SelectedTagUser([FromBody] SelectTagUserViewModel model)
		{
            var result = _accountManager.AddUserTag(model);
			return Json(result);
		}
	}
}
