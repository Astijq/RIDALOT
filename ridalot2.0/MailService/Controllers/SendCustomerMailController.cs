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
		public string send(string custEmail, string ownerEmail, string subject, string text, string key)
		{
			var client = new SendGridClient(key);
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
