using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

		
		public static string GetArticleURL(this string title)
		{
			title = title.ToLower().Replace(' ', '-');
			title = String.Join("", title.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Replace("ı", "i");
			return title;
		}

		public static string ContentFormat(this string content, int lenght)
		{
			
			string cleanText = Regex.Replace(content, "<.*?>", string.Empty).Replace("&nbsp;", "").Replace("&nbsp", "").Replace("&", " ");
			string newContent = cleanText.Substring(0,lenght);
			return newContent;
		}

		public static string GetTagUrl(this string tag)
		{
			tag = tag.ToLower().Replace(' ', '-');
			tag = String.Join("", tag.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Replace("ı", "i");
			return tag;
		}


	}
}
