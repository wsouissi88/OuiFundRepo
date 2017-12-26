using OuiFund.Domain.Model;


namespace OuiFund.Services.IServices
{
    public interface IEmailService
    {
        string SendAcountCredentiel(User user);
    }
}
