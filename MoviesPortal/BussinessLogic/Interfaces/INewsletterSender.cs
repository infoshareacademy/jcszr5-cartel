using System.Net.Mail;

namespace BusinessLogic.Interfaces
{
    public interface INewsletterSender
    {
        public Task SendNotyficationToSingleUser(string email, string name, string message, string subject);

        public Task SendNewsletterToAllSubscribents(string message, string subject);

        public MailMessage PrepareMailMessage(string email, string name, string message, string subject);

        public SmtpClient GetSmtpClient();

        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    }
}
