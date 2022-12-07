using MailSendReference;
using Microsoft.AspNetCore.Mvc;
using ridalot2._0.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ridalot2._0.Pages.PageSupport
{
    public class CustomerMail : LoginControl
    {
        sendMailPostedRequest p = new sendMailPostedRequest();
        public void send()
        {
            p(Email, GivenName);
        }
            //Email, GivenName
    }
}
