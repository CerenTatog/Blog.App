using Blog.Model.Models;

namespace Blog.BLL.Helper
{
	public interface IMailService
	{
		ServiceResult SendMail(List<string> toList, string konu, string body, List<string> ccList = null);
	}

}
