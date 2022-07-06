using System.Net.Mail;

namespace BusinessLogic.Interfaces
{
    public interface INewsletterService
    {
        public Task SendEmailNotyfication(string email, string name, string message, string subject, bool isMultipleEmail);

        public MailMessage PrepareMailMessage(string email, string name, string message, string subject, bool IsMultipleEmail);

        public SmtpClient GetSmtpClient();

        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    }
}
