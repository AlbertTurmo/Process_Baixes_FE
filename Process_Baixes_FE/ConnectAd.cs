using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;

namespace UnsubscribeR
{
   
    // Tots els close revisats
    public static class ConnectAd
    {
        public static string LookForMail(string WindowsId)
        {
            string Mail = string.Empty;
            PrincipalContext PrincipalContext = new PrincipalContext(ContextType.Domain);
            UserPrincipal UserPrincipal = UserPrincipal.FindByIdentity(PrincipalContext, WindowsId);

            if (UserPrincipal != null)
            {
                Mail = UserPrincipal.EmailAddress;
            }
            return Mail;
        }

        public static string LookForManager(string WindowsId)
        {

            string Mail = string.Empty;

            PrincipalContext PrincipalContext = new PrincipalContext(ContextType.Domain);
            UserPrincipal UserPrincipal = UserPrincipal.FindByIdentity(PrincipalContext, WindowsId);

            if(UserPrincipal!=null)
            {
                DirectoryEntry DirectoryEntry = (DirectoryEntry)UserPrincipal.GetUnderlyingObject();

                PropertyValueCollection Manager = DirectoryEntry.Properties["manager"];

                if (Manager.Count > 0)
                {
                    string DistinguishedManagerName = DirectoryEntry.Properties["manager"][0].ToString();
                    UserPrincipal UserPrincipalManager = UserPrincipal.FindByIdentity(PrincipalContext, IdentityType.DistinguishedName, DistinguishedManagerName);
                    Mail = UserPrincipalManager.EmailAddress;
                }
            }

            return Mail;
        }
    }
}
