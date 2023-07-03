using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Drive.v3;
using Google.Apis.Admin.Directory.directory_v1;

using GetGoogleUserCredentials;
using Google.Apis.Services;

namespace GetGoogleDriveService
{
    public static class GetDirectoryService
    {

        public static DirectoryService GetDirectoryServiceMethod()
        {

            UserCredential UserCredential = GUserCredentials.GetUserCredentials();


            BaseClientService.Initializer initializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = UserCredential,
                ApplicationName = "SyncAd",
            };


            DirectoryService DirectoryService = new DirectoryService();


            return DirectoryService;


        }

        













    }
}
