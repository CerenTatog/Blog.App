using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Blog.BLL.Helper
{
	public static class StringHelper
	{
		public static string GetUserNameByMail(this string email)
		{
			string userName = email.Split('@')[0];
			return userName;
		}

		public static string GetUserURLByMail(this string email)
		{

			string userUrl = email.Split('@')[0];
			return userUrl;
		}

		//burada bir id eklemesi de yapmak gerekir mi url'de?
		public static string GetArticleURL(this string title)
		{
			title = title.ToLower().Replace(' ', '-');
			title = String.Join("", title.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Replace("ı", "i");
			return title;
		}

		public static string ContentFormat(this string content)
		{
			string newContent = content.Substring(100);
			return newContent;
		}
	}
}
