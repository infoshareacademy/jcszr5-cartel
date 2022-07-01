namespace BusinessLogic.Interfaces
{
    public interface INewsletterSender
    {
        public Task SendWelcomeNotyficationToNewUser(string email, string name);

        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    }
}
