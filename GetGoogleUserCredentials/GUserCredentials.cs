using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace GetGoogleUserCredentials
{
    public static class GUserCredentials
    {

        public static UserCredential GetUserCredentials()
        {
            string[] Scopes = { DirectoryService.Scope.AdminDirectoryUser, DriveService.Scope.Drive, DriveService.Scope.DriveFile };

            UserCredential UserCredential;

            string CredentialsJsonFile = @"C:\OCA-DSI\BajasUsuario\Essentials\Credentials_Txema.json";

            using (FileStream FileStream = new FileStream(CredentialsJsonFile, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string CredentialFolderPath = @"C:\OCA-DSI\BajasUsuario\Essentials\Token";

                ClientSecrets ClientSecret = GoogleClientSecrets.FromStream(FileStream).Secrets;
                string User = "admin";
                FileDataStore FileDataStores = new FileDataStore(CredentialFolderPath, true);

                Task<UserCredential> TaskUserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(ClientSecret, Scopes, User, CancellationToken.None, FileDataStores);
                UserCredential = TaskUserCredential.Result;
                Console.WriteLine("Credential file saved to: " + CredentialFolderPath);
            }

            return UserCredential;

        }
    }
}
