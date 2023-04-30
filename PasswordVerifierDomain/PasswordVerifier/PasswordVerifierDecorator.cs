using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifierDomain.Password
{
    public class PasswordVerifierDecorator : IPasswordVerifier
    {
        private readonly IPasswordVerifier _passwordVerifier; 

        protected bool _valid;
        protected List<string> _errors;
        public PasswordVerifierDecorator(IPasswordVerifier passwordVerifier)
        {
            _passwordVerifier = passwordVerifier;
        }

        public bool IsValid()
        {
            return _passwordVerifier.IsValid() && _valid;
        }

        public List<string> ErrorsMessage()
        {
            return _passwordVerifier.ErrorsMessage().Concat(_errors).ToList();
        }
    }
}
