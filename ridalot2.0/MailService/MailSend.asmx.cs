using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace MailService
{
	/// <summary>
	/// Summary description for MailSend
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class MailSend : System.Web.Services.WebService
	{

		[WebMethod]
		public void sendMailPosted(string email, string name)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var msg = new SendGridMessage()
			{
				From = new EmailAddress("ridalot.info@gmail.com", "RIDALOT"),
				Subject = "Post Created Successfully",
				PlainTextContent = "Your post has been added, wait for someone to contact you about the pickup"
			};
			msg.AddTo(new EmailAddress(email, name));
			var response = client.SendEmailAsync(msg);
		}
		public void sendMailAccepted(string customerEmail, string customerName, string workerEmail, string workerName)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var msg = new SendGridMessage()
			{
				From = new EmailAddress("ridalot.info@gmail.com", "RIDALOT"),
				Subject = "Task Accepted",
				PlainTextContent = "Your upload for pickup has been accepted by: " + workerName + ", you can contact him: " + workerEmail
			};
			msg.AddTo(new EmailAddress(customerEmail, customerName));
			var response = client.SendEmailAsync(msg);

		}
	}
}
