namespace CostCalculation.Services.IServices
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(string resetPasswordEmailLink, string toEmail);
        Task SendPasswordUpdatedEmail(string toEmail);
        Task SendActivatedInfoEmail(string toEmail, bool approvedStatus);
    }
}
