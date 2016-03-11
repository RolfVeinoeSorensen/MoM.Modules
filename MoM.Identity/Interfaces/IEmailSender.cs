using System.Threading.Tasks;

namespace MoM.Identity.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
