namespace BusinessLogic.Interfaces
{
    public interface INewsletterSender
    {
        public Task SendNotyficationToSingleUser(string email, string name, string message);

        public void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    }
}
