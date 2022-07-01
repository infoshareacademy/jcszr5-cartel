using System.Net.Mail;

namespace BusinessLogic.Interfaces
{
    public interface INewsletterSender
    {
        public Task SendNotyficationToSingleUser(string email, string name, string message);

        public Task SendNewsletterToAllSubscribents(string message);

        public MailMessage PrepareMailMessage(string email, string name, string message);

        public SmtpClient GetSmtpClient();

        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    }
}
