using Blog.BLL.Helper;
using Blog.Model.ViewModels;

namespace Blog.BLL
{
    public interface IAccountManager
    {
        //bu kısımın dönüş tiplerinden ve alacağı parametrelerden emin değilim. Identity ya da jwt yüklenip yüklenmeyeceğine karar verilmesi gerek. 
        ServiceResult SignIn(UserRegisterViewModel uvm);
        UserViewModel SignOut(UserViewModel uvm);
        ServiceResult Register(UserRegisterViewModel uvm);
        ServiceResult<SelectTagViewModel> ActivatedMail(string guid);
        ServiceResult SignInMail(string guid);
	}
}
