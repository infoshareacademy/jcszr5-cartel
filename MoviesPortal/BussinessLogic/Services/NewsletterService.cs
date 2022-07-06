using BusinessLogic.Interfaces;
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

        public async Task SendEmailNotyfication(string email, string name, string message, string subject, bool iSMultipleEmail)
        {
            _smtp = GetSmtpClient();

            _smtp.SendCompleted += OnSendCompleted;

            _mail = PrepareMailMessage(email, name, message, subject, iSMultipleEmail);

            await _smtp.SendMailAsync(_mail);
        }

        public MailMessage PrepareMailMessage(string email, string name, string message, string subject, bool isMultipleEmail)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(_senderEmail, _senderName);
            var allSubscriptions = _subscriptionService.GetAllSubscriptions();
            if (isMultipleEmail)
            {
                foreach (var subscription in allSubscriptions)
                {
                    mail.Bcc.Add(new MailAddress(subscription.Email, subscription.FirstName));
                    mail.Body = $"Hi there, {message}";
                }
            }
            else
            {
                mail.To.Add(new MailAddress(email, name));
                mail.Body = $"Hello {name}, {message}";
            }

            /*            mail.IsBodyHtml = true;*/
            mail.Subject = subject;
            mail.BodyEncoding = Encoding.UTF8;
            mail.SubjectEncoding = Encoding.UTF8;

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


