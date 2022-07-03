using BusinessLogic.Interfaces;
using DataAccess.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly ISubscriptionService _subscriptionService;
        private string _senderEmail = "cartel.movieportal@gmail.com";
        private string _senderEmailPassword = "yfzbjzpoltoviqwx";
        private string _senderName = "Zespół Cartel MoviePortal";
        private SmtpClient _smtp;
        private MailMessage _mail;

        public NewsletterService(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        public async Task SendNotyficationToSingleUser(string email, string name, string message, string subject)
        {
            _smtp = GetSmtpClient();

            _smtp.SendCompleted += OnSendCompleted;

            _mail = PrepareMailMessage(email, name, message, subject);

            await _smtp.SendMailAsync(_mail);

        }

        public async Task SendNewsletterToAllSubscribents(string message, string subject)
        {
            _smtp = GetSmtpClient();
            /*            var allSubscriptionsEmails = _subscriptionService.GetAllSubscriptions().Select(s => s.Email);*/
            var allSubscriptions = _subscriptionService.GetAllSubscriptions();
            /*            string allEmailsJoined = string.Join(";", allSubscriptionsEmails);*/


            foreach (SubscriptionModel subscription in allSubscriptions)
            {
                string email = subscription.Email;
                string name = subscription.FirstName;
                var mail = PrepareMailMessage(email, name, message, subject);
                await _smtp.SendMailAsync(mail);
            }

            _smtp.SendCompleted += OnSendCompleted;


            _mail = PrepareMailMessage(
                _senderEmail,
                _senderName,
                "Newsletter to all subscribed users has been send",
                "newsletter post confirmation");

            await _smtp.SendMailAsync(_mail);
        }

        public MailMessage PrepareMailMessage(string email, string name, string message, string subject)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(_senderEmail, _senderName);
            mail.To.Add(new MailAddress(email));
            mail.IsBodyHtml = true;
            mail.Subject = subject;
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
