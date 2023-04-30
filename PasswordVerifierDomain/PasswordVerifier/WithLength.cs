using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifierDomain.Password
{
    public class WithLength : PasswordVerifierDecorator
    {
        private readonly string _password;
        public WithLength(IPasswordVerifier passwordVerifier, string password) : base(passwordVerifier)
        {
            _password = password; 

            _errors = ErrorsMessage();
            _valid = IsValid();
        }

        private List<string> ErrorsMessage()
        {
            if (!IsValid()) return new List<string> { "the password must be at least 8 characters long" };
            return new List<string>();
        }

        private bool IsValid()
        {
            return _password.Length >= 8;
        }
    }
}
