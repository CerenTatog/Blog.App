using System.Net.Mail;
using System.Net;
using Blog.Model.Models;

namespace Blog.BLL.Helper
{
	public class MailService : IMailService
	{
		public ServiceResult SendMail(List<string> toList, string konu, string body, List<string> ccList = null)
		{
			using (MailMessage mail = new MailMessage())
			{
				try
				{
					mail.From = new MailAddress("foresightblog@gmail.com", "Foresight");

					foreach (string gonderilecek in toList)
					{
						mail.To.Add(gonderilecek);
					}

					if (ccList?.Count > 0)
					{
						foreach (string cc in ccList)
						{
							mail.CC.Add(cc);
						}
					}

					mail.Subject = konu;
					mail.Body = body;
					mail.IsBodyHtml = true;
					using (SmtpClient smtp = new SmtpClient())
					{
						smtp.Credentials = new NetworkCredential("foresightblog@gmail.com", "qxkcwfuzmsdprwfk");
						smtp.Port = 587;
						smtp.Host = "smtp.gmail.com";
						smtp.EnableSsl = true;
						smtp.Timeout = 10000;
						smtp.UseDefaultCredentials = false;
						smtp.Send(mail);
					}
					return new ServiceResult("", ServiceResultState.SUCCESS);
				}
				catch (Exception ex)
				{
					return new ServiceResult(ex.Message, ServiceResultState.ERROR);
				}
			}
		}
	}

}
