using PasswordVerifierDomain.Password;

namespace PasswordVerifierDomain
{
    public static class PasswordChecker
    {
        public static (bool, string) GetResponse(string password)
        {
            IPasswordVerifier passwordVerify = Check(password);
            var stringErrors = "";
            if (passwordVerify.ErrorsMessage().Any())
            {
                stringErrors = passwordVerify.ErrorsMessage().Aggregate((e, e1) => e + Environment.NewLine + e1);
            }
            return (passwordVerify.IsValid(), stringErrors);
        }

        private static IPasswordVerifier Check (string password)
        {
            IPasswordVerifier verifier = new PasswordVerifierBase(password);
            verifier = new WithLength(verifier, password);
            verifier = new WithDigits(verifier, password);
            verifier = new WithUpperCharacter(verifier, password);
            verifier = new WithSpeicalCharacter(verifier, password);
            return verifier;
        }
    }
}
