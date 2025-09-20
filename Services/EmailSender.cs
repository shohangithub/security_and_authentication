using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Implement SMTP or use an external provider
        var smtpClient = new SmtpClient("smtp.yourserver.com")
        {
            Credentials = new NetworkCredential("yourUser", "yourPassword"),
            EnableSsl = true
        };

        var message = new MailMessage("no-reply@yourapp.com", email, subject, htmlMessage)
        {
            IsBodyHtml = true
        };

        await smtpClient.SendMailAsync(message);
    }
}
