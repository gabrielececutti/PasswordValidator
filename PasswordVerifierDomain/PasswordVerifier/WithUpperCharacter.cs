using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifierDomain.Password
{
    public class WithUpperCharacter : PasswordVerifierDecorator
    {
        private readonly string _password;
        public WithUpperCharacter(IPasswordVerifier passwordVerifier, string password) : base(passwordVerifier)
        {
            _password = password;

            _errors = ErrorsMessage();
            _valid = IsValid();
        }

        private List<string> ErrorsMessage()
        {
            if (!IsValid()) return new List<string>() { "the password must contain at least one uppercase character" };
            return new List<string>();
        }

        private bool IsValid()
        {
            foreach (var character in _password) if (char.IsUpper(character)) return true;
            return false;
        }
    }
}
