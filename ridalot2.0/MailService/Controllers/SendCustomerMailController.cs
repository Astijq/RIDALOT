using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MailService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SendCustomerMailController : ControllerBase
	{
		[HttpGet]
		public string sendMail(string custEmail, string ownerEmail, string subject, string text, string key)
		{
			var apiKey = key;
			var client = new SendGridClient(apiKey);
			var msg = new SendGridMessage()
			{
				From = new EmailAddress(ownerEmail),
				Subject = subject,
				PlainTextContent = text
			};
			msg.AddTo(new EmailAddress(custEmail));
			var response = client.SendEmailAsync(msg);
			return "success";
		}

	}
}
