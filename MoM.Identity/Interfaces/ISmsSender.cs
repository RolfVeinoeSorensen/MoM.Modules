using System.Threading.Tasks;

namespace MoM.Identity.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
