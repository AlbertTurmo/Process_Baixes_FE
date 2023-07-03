using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Drive.v3;

using GetGoogleUserCredentials;
using Google.Apis.Services;

namespace GetGoogleDriveService
{
    public static class GetDriveService
    {

        public static DriveService GetDriveServiceMethod()
        {

            UserCredential UserCredential = GUserCredentials.GetUserCredentials();


            BaseClientService.Initializer initializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = UserCredential,
                ApplicationName = "SyncAd",
            };

            DriveService DriveService = new DriveService(initializer);


            return DriveService;


        }

        













    }
}
