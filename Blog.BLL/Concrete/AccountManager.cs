using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BLL.Helper;
using Blog.DAL.GenericRepository;
using Blog.Model.ViewModels;
using Blog.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.BLL
{
	public class AccountManager : IAccountManager
	{
		private readonly IHttpContextAccessor _contextAccessor;
		private IUnitOfWork _db;
		private IMailService _mailService;
		private UserViewModel _currentUser;
		public AccountManager(IHttpContextAccessor contextAccessor, IUnitOfWork db, IMailService mailService)
		{
			_contextAccessor = contextAccessor;
			_db = db;
			_mailService = mailService;
		}

		public ServiceResult<ActivatedMailResponseViewModel> ActivatedMail(string guid)
		{
			var user = _db.UserRepository.GetAll().FirstOrDefault(x => x.ActivationGuid == guid);
			if (user == null)
			{
				return new ServiceResult<ActivatedMailResponseViewModel>(null, "Kullanıcı bulunamadı", ServiceResultState.ERROR);
			}
			if (user.IsEmailActivated)
			{
				return new ServiceResult<ActivatedMailResponseViewModel>(null, "Aktivasyon işlemi daha önce yapılmıştır", ServiceResultState.WARNING);
			}
			user.IsEmailActivated = true;
			_db.UserRepository.Update(user);
			var tagList = _db.TagRepository.GetAll().Select(x => new SelectListItem()
			{
				Selected = false,
				Text = x.TagName,
				Value = x.ID.ToString()
			}).ToList();
			ActivatedMailResponseViewModel result = new ActivatedMailResponseViewModel();
			result.UserId = user.ID;
			result.TagList = tagList;
			return new ServiceResult<ActivatedMailResponseViewModel>(result, "", ServiceResultState.SUCCESS);
		}

		public ServiceResult SignInMail(string guid)
		{
			var user = _db.UserRepository.GetAll().FirstOrDefault(x => x.ActivationGuid == guid);
			if (user == null)
			{
				return new ServiceResult("Kullanıcı bulunamadı", ServiceResultState.ERROR);
			}
			// session doldur
			_contextAccessor.HttpContext.Session.Set<UserViewModel>("user", new UserViewModel()
			{
				Id = user.ID,
				Email = user.Email,
				UserName = user.UserName,
				PictureUrl = user.PictureUrl,
				ProfileDescription = user.ProfileDescription
			});

			return new ServiceResult("", ServiceResultState.SUCCESS);
		}

		public ServiceResult Register(UserRegisterViewModel model)
		{
			bool userCheck = _db.UserRepository.GetAll().Any(x => x.Email == model.Email);
			if (userCheck)
			{
				return new ServiceResult("Aynı mail bilgisine ait kullanıcı bulunmaktadır.", ServiceResultState.WARNING);
			}
			User user = new User()
			{
				Email = model.Email,
				IsEmailActivated = false,
				//Password = model.Password,// hasleme koyulacak
				ProfileUrl = model.Email.GetUserURLByMail(),
				UserName = model.Email.GetUserNameByMail(),
				ActivationGuid = Guid.NewGuid().ToString()
			};
			_db.UserRepository.Create(user);
			string mailLink = $"https://localhost:7219/account/activatedmail/{user.ActivationGuid}";
			_mailService.SendMail(new List<string>() { model.Email }, "Hesap Aktivasyon", mailLink);

			return new ServiceResult("Başarı ile kayıt yapıldı. Aktivasyon linki mail edresinize gönderildi");
		}

		public ServiceResult SignIn(UserRegisterViewModel model)
		{
			var user = _db.UserRepository.GetAll().FirstOrDefault(x => x.Email == model.Email);
			if (user == null)
			{
				return new ServiceResult("Kullanıcı bilgisi bulunamadı", ServiceResultState.ERROR);
			}
			if (!user.IsEmailActivated)
			{
				return new ServiceResult("Lütfen aktivasyon işlemini gerçekleştiriniz", ServiceResultState.WARNING);
			}
			user.ActivationGuid = Guid.NewGuid().ToString();
			_db.UserRepository.Update(user);

			string mailLink = $"https://localhost:7219/account/signinmail/{user.ActivationGuid}";
			_mailService.SendMail(new List<string>() { model.Email }, "Hesap Giriş", mailLink);

			return new ServiceResult("Giriş linki mail edresinize gönderildi");
		}

		public UserViewModel SignOut(UserViewModel uvm)
		{
			throw new NotImplementedException();
		}

		public ServiceResult AddUserTag(SelectTagUserViewModel model)
		{
			List<int> idList = model.TagIds.Select(x => int.Parse(x)).ToList();
			foreach (var item in idList)
			{
				bool tagCheck = _db.UserTagRepository.GetAll().Any(x => x.TagId == item && x.UserId == model.UserId);
				if (tagCheck)
				{
					continue;
				}
				UserTag userTag = new UserTag()
				{
					CreatedBy = model.UserId,
					TagId = item,
					UserId = model.UserId
				};
				_db.UserTagRepository.Create(userTag);
			}
			return new ServiceResult("İşlem başarılı. Giriş sayfasına yönlendiriliyorsunuz.");
		}
	}
}
