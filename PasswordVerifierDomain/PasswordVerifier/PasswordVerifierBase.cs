using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifierDomain.Password
{
    public class PasswordVerifierBase : IPasswordVerifier
    {
        private readonly string _password;

        public PasswordVerifierBase(string password)
        {
            _password = password;
        }

        public List<string> ErrorsMessage()
        {
            if (!IsValid()) return new List<string> { "the password must contain at least one character" };
            return new List<string>();
        }

        public bool IsValid() => !string.IsNullOrEmpty(_password);
    }
}
