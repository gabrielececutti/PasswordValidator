using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifierDomain.Password
{
    public class WithSpeicalCharacter : PasswordVerifierDecorator
    {
        private readonly string _password;
        public WithSpeicalCharacter(IPasswordVerifier passwordVerifier, string password) : base(passwordVerifier)
        {
            _password = password;

            _errors = ErrorsMessage();
            _valid = IsValid();
        }

        private List<string> ErrorsMessage()
        {
            if (!IsValid()) return new List<string>() { "the password must contain at least one special character" };
            return new List<string>();
        }

        private bool IsValid()
        {
            return HasSpecialChars(_password);
        }

        private bool HasSpecialChars(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}
