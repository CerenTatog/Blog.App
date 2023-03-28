using Blog.BLL.Helper;
using Blog.Model.ViewModels;

namespace Blog.BLL
{
    public interface IAccountManager
    {
        //Tüm sign in vs. metotlar tanımlanacak. Identity ya da jwt yüklenip yüklenmeyeceğine karar verilmesi gerek. 
        ServiceResult SignIn(UserRegisterViewModel uvm);
        UserViewModel SignOut(UserViewModel uvm);
        ServiceResult Register(UserRegisterViewModel uvm);
        ServiceResult<ActivatedMailResponseViewModel> ActivatedMail(string guid);
        ServiceResult SignInMail(string guid);
        ServiceResult AddUserTag(SelectTagUserViewModel model);
	}
}
