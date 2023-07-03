using System;
using System.Text;
using System.Collections;
using System.Web.Security;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace UnsubscribeR
{
    public static class LdapAuthenticator
    {
        // Revisat close
        public static bool Validate(string User, string Password)
        {
            bool IsValidate = false;
            string Domain = "orior.int";
            using (PrincipalContext PrincipalContext = new PrincipalContext(ContextType.Domain, Domain)) //1 open
            {
                IsValidate = PrincipalContext.ValidateCredentials(User, Password);
            }
            return IsValidate;
        }
    }
}