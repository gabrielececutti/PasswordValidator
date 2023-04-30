namespace PasswordVerifierDomain.Password
{
    public interface IPasswordVerifier
    {
        bool IsValid();
        List<string> ErrorsMessage();
    }
}