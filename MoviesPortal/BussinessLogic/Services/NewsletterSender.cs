using BusinessLogic.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic.Services
{
    public class NewsletterSender : INewsletterSender
    {
        private SmtpClient _smtp;
        private MailMessage _mail;

        private string _hostSmtp = "smtp.gmail.com";
        private bool _enableSsl = true;
        private int _port = 587;
        private string _senderEmail = "cartel.movieportal@gmail.com";
        private string _senderEmailPassword = "yfzbjzpoltoviqwx";
        private string _senderName = "Zespół Cartel MoviePortal";


        public async Task SendWelcomeNotyficationToNewUser(string email, string name)
        {
            _mail = new MailMessage();
            _mail.From = new MailAddress(_senderEmail, _senderName);
            _mail.To.Add(new MailAddress(email));
            _mail.IsBodyHtml = true;
            _mail.Subject = $"You have registered in Cartel MoviePortal!";
            _mail.BodyEncoding = Encoding.UTF8;
            _mail.SubjectEncoding = Encoding.UTF8;
            _mail.Body = $"{name}, You have registered in Cartel MoviePortal, Congratulations!";

            _smtp = new SmtpClient
            {
                Host = _hostSmtp,
                EnableSsl = _enableSsl,
                Port = _port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderEmail, _senderEmailPassword)
            };

            _smtp.SendCompleted += OnSendCompleted;

            await _smtp.SendMailAsync(_mail);
        }

        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _smtp.Dispose();
            _mail.Dispose();
        }
    }
}
