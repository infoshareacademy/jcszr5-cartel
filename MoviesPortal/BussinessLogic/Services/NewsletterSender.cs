using BusinessLogic.Interfaces;
using DataAccess.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic.Services
{
    public class NewsletterSender : INewsletterSender
    {
        private readonly SubscriptionService _subscriptionService;
        private string _senderEmail = "cartel.movieportal@gmail.com";
        private string _senderEmailPassword = "yfzbjzpoltoviqwx";
        private string _senderName = "Zespół Cartel MoviePortal";
        private SmtpClient _smtp;
        private MailMessage _mail;


        public async Task SendNotyficationToSingleUser(string email, string name, string message)
        {
            _smtp = GetSmtpClient();

            _smtp.SendCompleted += OnSendCompleted;

            _mail = PrepareMailMessage(email, name, message);

            await _smtp.SendMailAsync(_mail);

            await SendNewsletterToAllSubscribents(message);
        }

        public async Task SendNewsletterToAllSubscribents(string message)
        {
            _smtp = GetSmtpClient();
            _smtp.SendCompleted += OnSendCompleted;
            var allSubscriptions = _subscriptionService.GetAllSubscriptions();

            foreach (SubscriptionModel subscription in allSubscriptions)
            {
                string email = subscription.Email;
                string name = subscription.FirstName;
                var mail = PrepareMailMessage(email, name, message);
                await _smtp.SendMailAsync(_mail);
            }
        }


        public MailMessage PrepareMailMessage(string email, string name, string message)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(_senderEmail, _senderName);
            mail.To.Add(new MailAddress(email));
            mail.IsBodyHtml = true;
            mail.Subject = $"You have registered in Cartel MoviePortal!";
            mail.BodyEncoding = Encoding.UTF8;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = $"{name}\n, {message}";
            return mail;
        }


        public SmtpClient GetSmtpClient()
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderEmail, _senderEmailPassword)
            };
        }


        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _smtp.Dispose();
            _mail.Dispose();
        }
    }
}
