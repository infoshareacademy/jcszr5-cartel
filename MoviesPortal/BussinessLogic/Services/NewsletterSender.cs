using BusinessLogic.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic.Services
{
    public class NewsletterSender : INewsletterSender
    {

        private string _hostSmtp = "smtp.gmail.com";
        private bool _enableSsl = true;
        private int _port = 587;
        private string _senderEmail = "cartel.movieportal@gmail.com";
        private string _senderEmailPassword = "yfzbjzpoltoviqwx";
        private string _senderName = "Zespół Cartel MoviePortal";


        public async Task SendNotyficationToSingleUser(string email, string name, string message)
        {
            var _mail = PrepareMailMessage(email, name, message)

            var _smtp = GetSmtpClient(_senderEmail, _senderEmailPassword);

            _smtp.SendCompleted += OnSendCompleted;

            await _smtp.SendMailAsync(_mail);
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
            mail.Body = $"{name}, {message}";
            return mail;
        }



        public SmtpClient GetSmtpClient(string senderEmail, string senderEmailPassword)
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, senderEmailPassword)
            }
        }


        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _smtp.Dispose();
            _mail.Dispose();
        }
    }
}
