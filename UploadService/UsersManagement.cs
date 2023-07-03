using System;
using System.Threading;

using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

using GoogleUser = Google.Apis.Admin.Directory.directory_v1.Data.User;

namespace GoogleServices
{
    public static class UsersManagement
    {

        public static bool CheckIfUserExists(string PrimaryMail)
        {
            bool Exists = false;

            Users Users = GetUsersList(PrimaryMail);

            if (Users.UsersValue != null)
            {
                if (Users.UsersValue.Count > 0)
                {
                    Exists = true;
                }
            }

            return Exists;
        }


        public static GoogleUser GetUser(string PrimaryMail)
        {
            DirectoryService DirectoryServices = GetDirectoryService();

            UsersResource.GetRequest Request = DirectoryServices.Users.Get(PrimaryMail);

            GoogleUser GoogleUser = Request.Execute();

            return GoogleUser;

        }


        public static GoogleUser GetUser_BChangePassword(string PrimaryMail)
        {

            DirectoryService DirectoryServices = GetDirectoryService();

            UsersResource.GetRequest Request = DirectoryServices.Users.Get(PrimaryMail);

            GoogleUser GoogleUser = Request.Execute();

            GoogleUser.Password = "GNe>=9Zd8=G73uQb";

            UsersResource.UpdateRequest UpdateRequest = DirectoryServices.Users.Update(GoogleUser, GoogleUser.Id);

            var ndnd = UpdateRequest.Execute();


            return GoogleUser;


        }

        public static Users GetUsersList(string PrimaryMail)
        {
            DirectoryService DirectoryServices = GetDirectoryService();

            UsersResource.ListRequest UsersListRequest = DirectoryServices.Users.List();
            UsersListRequest.Customer = "my_customer";
            UsersListRequest.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;
            UsersListRequest.Query = $"email='{PrimaryMail}'";
            Users users = UsersListRequest.Execute();

            return users;

        }

        public static bool DeleteUser(string PrimaryMail)
        {

            bool Success = false;

            DirectoryService DirectoryServices = GetDirectoryService();

            UsersResource.DeleteRequest DeleteRequest = DirectoryServices.Users.Delete(PrimaryMail);
            try
            {
                string Result = DeleteRequest.Execute();
                Success = true;
            }
            catch(Exception Exception)
            {
                Success = false;

                throw Exception;

            }

            return Success;

        }


        public static bool UnDeleteUsers(string UnitOrg, string PrimaryMail)
        {
            bool Success = false;

            DirectoryService DirectoryServices = GetDirectoryService();

            UserUndelete UserToUndelete = new UserUndelete();
            UserToUndelete.OrgUnitPath = UnitOrg;



            UsersResource.UndeleteRequest UndeleteRequest = DirectoryServices.Users.Undelete(UserToUndelete, PrimaryMail);
            string Result = UndeleteRequest.Execute();

            return Success;

        }



        public static bool CreateAlias(string AliasMail, string PrimaryMail)
        {
            bool Success = false;

            Alias AliasBody = new Alias
            {
                AliasValue = AliasMail
            };

            DirectoryService DirectoryServices = GetDirectoryService();
            UsersResource.AliasesResource.InsertRequest InsertRequest = DirectoryServices.Users.Aliases.Insert(AliasBody, PrimaryMail);

            try
            {
                Alias Alias = InsertRequest.Execute();
                Success = true;
            }
            catch (Exception Exception)
            {
                Success = false;
            }

            return Success;

        }

        public static bool DeleteAllAliasFromUser(string PrimaryMail)
        {
            bool Success = false;
            DirectoryService DirectoryServices = GetDirectoryService();


            Aliases Aliases = DirectoryServices.Users.Aliases.List(PrimaryMail).Execute();

            if (Aliases.AliasesValue != null)
            {
                foreach (Alias alias in Aliases.AliasesValue)
                {

                    var result = DirectoryServices.Users.Aliases.Delete(PrimaryMail, alias.AliasValue).Execute();
                }
            }

            return Success;

        }



        private static DirectoryService GetDirectoryService()
        {
            string[] Scopes = { DirectoryService.Scope.AdminDirectoryUser };

            // string JsonCredentials = Encoding.UTF8.GetString(UploadService.Properties.Resources.Credentials);

            string JsonCredentials = GetCredentialJson();

            GoogleCredential GoogleCredential = GoogleCredential.FromJson(JsonCredentials);
            GoogleCredential = GoogleCredential.CreateScoped(Scopes);
            GoogleCredential = GoogleCredential.CreateWithUser("txema.ortega@ocaglobal.com");
            ServiceAccountCredential ServiceAccountCredential = GoogleCredential.UnderlyingCredential as ServiceAccountCredential;

            if (ServiceAccountCredential.RequestAccessTokenAsync(CancellationToken.None).Result)
            {
                Console.WriteLine("access token: " + ServiceAccountCredential.Token.AccessToken);
            }

            // Create Google Sheets API service.
            DirectoryService DirectoryServices = new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = ServiceAccountCredential,
                ApplicationName = "My First Project"
            });
            return DirectoryServices;
        }


        private static string GetCredentialJson()
        {
            string CredentialsJson =
                "{" +
                "\"type\": \"service_account\"," +
                "\"project_id\": \"ocaglobal\"," +
                "\"private_key_id\": \"373f739aaf93d6a134ad480b675b51ba595de29f\"," +
                "\"private_key\": \"-----BEGIN PRIVATE KEY-----\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDRqvSWrJtyMdGg\nj9gy5xABZv7SkqRgUKIOEOeWXdG/Jgg7GYWFneT6sTEX0+TRevpE7LgF1gWmc1Tn\n9yqzJrOEWZBDXVb5cxpZA1HibE5reSYSyary/iP6zDSHbGjXkmqilZczZJMeeFce\nYiM7sMOc1MwtOwpjzTfibAEzhde9m8SdzcqfJTixO8iKHGRIpmhTi/I5+FM8ue0Y\njeLODatvmyaCcJxwdpR621fJxXEy3wuUWNCmu68Qe07KUo8XsZvgXQM9GSdUrZUi\nKCTxobqpV2FCW2rdkm8r0o/YDv4JyEbLNPF0pg0aGMX69H7ACMjGy1HRp8fAyLP8\nonwgyq3VAgMBAAECggEAAPP7FT1z0W+RIxIBHhSEM2ihi0x+WC+8Cz6GOirZm4a6\nB9nxJbvWtB44RmiNd2qzMFTRIbmo04P3sVXWySZJlgLtAtlhEVScHIze0B3E6q+L\n/dur0ShYx1JeGyiusbgpKVPVWNCOuKQJMiRCqIoaDlO+f9m79A5iDPK67xFSYaEn\nBErAZbHQz2XFK4vxAULPcPMPPBOqz0H8P1YJmGa900T/Wn/la1bZmLtMUHwZ2rfW\n/HLZEvUPcqveF9mzFRCYAXVdiNMP97gqXjy2Exthz26JH2UM55rRhtwk5ecfTiuu\nK7J+PVSbg7hwylIbn2gfo0mP6nvb7bshkU94YYKSCwKBgQD/2RdmYMIEWwUBpOpm\nJfu783J6ovLOmtj59PIkscNEVrwxq4U0YHeDZlbFjas5U5reHQm0Z13JmO3XNcRC\ngq0Q1XtRWi4Ow9X5pm9n6Wl71YhV/UNLXz9ahLLrjlDT8gOfyVcKTGGTMCcHvDl0\nEidMkpPkRTfZNmuTC1eeF7ot9wKBgQDRytdQWmQlSW0zlqQR5fvLQrWJ3OKN5E+L\nI7URARqDnjjpEagEbvsVOId0FhshQTyyltFePbRXpa+zHiTUN8yJ92Y2aB6/5Yum\n0wyZyH5EfLefe0GhSyxiA0VRPA/LqBCrUsM7RGnntvAD4rInMnBFSD1ExqL3ZnpD\nBeJgwmG/kwKBgQCmawqKgGOTO7VM9X22hfxxrBAJ71Yqx5RdOlQLREm0eQqe8GeL\nwzfaE8ZbaCQ4/MXetlqqqxXZXQ1QEFwhuyhhq8s0Bomw9veHFRigKbaAY0v0SvHr\n4/+snGZZTFANHP34gJmKTFanzAmHQYrJkklXyHxEXjXOp1Rf6F/MqLhkzwKBgQDQ\nAmLCVR1+qvMPd4luBa5Gtvnwm4Y2Ue1cdCcPmRyE69hZnxwMaU2imM4VF+YGbvyT\nxl4JJv0s+ibfXj/9+uVe1mIOB+aVNi/lVNTllZk8prwZ8Mf9+N8kv0F3binrL9R3\nSjQxC4BGM2h/McKagrQ2vY2iJ6Fl08HdunPepFzu6QKBgQDdB5MUX/Tw2sT6v5+T\nd8r4hLEjVaDp7aZsxum0KAaEiLtpB6kB9NtZp9UIuyOE9Hpk0YoeKZImu5qJurj8\nACI+awqVfYvG4N6eQ9h12XqxhpiSPd6KS2cdzlN/64j8/h0WPnu4LOLAd8tC5mN5\nBTSPUaVbOB5nEk/AhrAdLoMbxw==\n-----END PRIVATE KEY-----\n\"," +
                "\"client_email\": \"servicio-ocadsi@ocaglobal.iam.gserviceaccount.com\"," +
                "\"client_id\": \"111145958131745756573\"," +
                "\"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\"," +
                "\"token_uri\": \"https://oauth2.googleapis.com/token\"," +
                "\"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\"," +
                "\"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/servicio-ocadsi%40ocaglobal.iam.gserviceaccount.com\"" +
                "}";

            return CredentialsJson;
        }

        /*
         * 
         * 
         * 
         {
            \"type\": \"service_account\",
            \"project_id\": \"ocaglobal\",
            \"private_key_id\": \"373f739aaf93d6a134ad480b675b51ba595de29f\",
            \"private_key\": \"-----BEGIN PRIVATE KEY-----\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDRqvSWrJtyMdGg\nj9gy5xABZv7SkqRgUKIOEOeWXdG/Jgg7GYWFneT6sTEX0+TRevpE7LgF1gWmc1Tn\n9yqzJrOEWZBDXVb5cxpZA1HibE5reSYSyary/iP6zDSHbGjXkmqilZczZJMeeFce\nYiM7sMOc1MwtOwpjzTfibAEzhde9m8SdzcqfJTixO8iKHGRIpmhTi/I5+FM8ue0Y\njeLODatvmyaCcJxwdpR621fJxXEy3wuUWNCmu68Qe07KUo8XsZvgXQM9GSdUrZUi\nKCTxobqpV2FCW2rdkm8r0o/YDv4JyEbLNPF0pg0aGMX69H7ACMjGy1HRp8fAyLP8\nonwgyq3VAgMBAAECggEAAPP7FT1z0W+RIxIBHhSEM2ihi0x+WC+8Cz6GOirZm4a6\nB9nxJbvWtB44RmiNd2qzMFTRIbmo04P3sVXWySZJlgLtAtlhEVScHIze0B3E6q+L\n/dur0ShYx1JeGyiusbgpKVPVWNCOuKQJMiRCqIoaDlO+f9m79A5iDPK67xFSYaEn\nBErAZbHQz2XFK4vxAULPcPMPPBOqz0H8P1YJmGa900T/Wn/la1bZmLtMUHwZ2rfW\n/HLZEvUPcqveF9mzFRCYAXVdiNMP97gqXjy2Exthz26JH2UM55rRhtwk5ecfTiuu\nK7J+PVSbg7hwylIbn2gfo0mP6nvb7bshkU94YYKSCwKBgQD/2RdmYMIEWwUBpOpm\nJfu783J6ovLOmtj59PIkscNEVrwxq4U0YHeDZlbFjas5U5reHQm0Z13JmO3XNcRC\ngq0Q1XtRWi4Ow9X5pm9n6Wl71YhV/UNLXz9ahLLrjlDT8gOfyVcKTGGTMCcHvDl0\nEidMkpPkRTfZNmuTC1eeF7ot9wKBgQDRytdQWmQlSW0zlqQR5fvLQrWJ3OKN5E+L\nI7URARqDnjjpEagEbvsVOId0FhshQTyyltFePbRXpa+zHiTUN8yJ92Y2aB6/5Yum\n0wyZyH5EfLefe0GhSyxiA0VRPA/LqBCrUsM7RGnntvAD4rInMnBFSD1ExqL3ZnpD\nBeJgwmG/kwKBgQCmawqKgGOTO7VM9X22hfxxrBAJ71Yqx5RdOlQLREm0eQqe8GeL\nwzfaE8ZbaCQ4/MXetlqqqxXZXQ1QEFwhuyhhq8s0Bomw9veHFRigKbaAY0v0SvHr\n4/+snGZZTFANHP34gJmKTFanzAmHQYrJkklXyHxEXjXOp1Rf6F/MqLhkzwKBgQDQ\nAmLCVR1+qvMPd4luBa5Gtvnwm4Y2Ue1cdCcPmRyE69hZnxwMaU2imM4VF+YGbvyT\nxl4JJv0s+ibfXj/9+uVe1mIOB+aVNi/lVNTllZk8prwZ8Mf9+N8kv0F3binrL9R3\nSjQxC4BGM2h/McKagrQ2vY2iJ6Fl08HdunPepFzu6QKBgQDdB5MUX/Tw2sT6v5+T\nd8r4hLEjVaDp7aZsxum0KAaEiLtpB6kB9NtZp9UIuyOE9Hpk0YoeKZImu5qJurj8\nACI+awqVfYvG4N6eQ9h12XqxhpiSPd6KS2cdzlN/64j8/h0WPnu4LOLAd8tC5mN5\nBTSPUaVbOB5nEk/AhrAdLoMbxw==\n-----END PRIVATE KEY-----\n\",
            \"client_email\": \"servicio-ocadsi@ocaglobal.iam.gserviceaccount.com\",
            \"client_id\": \"111145958131745756573\",
            \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",
            \"token_uri\": \"https://oauth2.googleapis.com/token\",
            \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",
            \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/servicio-ocadsi%40ocaglobal.iam.gserviceaccount.com\"
        }

         
         */





    }
}
