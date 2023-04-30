using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifierDomain.Password
{
    public class WithDigits : PasswordVerifierDecorator
    {
        private readonly string _password;
        public WithDigits(IPasswordVerifier passwordVerifier, string password) : base(passwordVerifier)
        {
            _password = password;

            _errors = ErrorsMessage();
            _valid = IsValid();
        }

        private List<string> ErrorsMessage()
        {
            if (!IsValid()) return new List<string> { "the password must contain at least two numbers" };
            return new List<string>();
        }

        private bool IsValid()
        {
            int count = 0;
            foreach (var character in _password)
            {
                if (int.TryParse(character.ToString(), out int result)) count++;
            }
            return count >= 2;
        }
    }
}
