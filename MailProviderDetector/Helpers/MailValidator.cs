namespace MailProviderDetector.Helpers
{
    public class MailValidator
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                // to validate the format of the mail string, we set a new Mail instance 
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
