using System.Threading.Tasks;

namespace УниверсальноеПриложение.Сервисы
{
    public interface IEmailVerificationService
    {
        Task SendVerificationCodeAsync(string email, string code);
        string GenerateCode();
        bool VerifyCode(string email, string enteredCode);
        void RemoveCode(string email);
    }
}
