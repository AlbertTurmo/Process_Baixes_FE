using GetGoogleDriveService;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Upload;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using GoogleFile = Google.Apis.Drive.v3.Data.File;

namespace GoogleServices
{
    public static class UploadFile
    {
        public static bool UploadFileToGoogleDrive(string FileToUpload, out string ExceptionMessage, out bool SuccesCO)
        {
            ExceptionMessage = string.Empty;
            bool Success = false;
            SuccesCO = false;

            FileInfo FileInfo = new FileInfo(FileToUpload);

            if (FileInfo.Exists)
            {
                // sortir avisant
                string test_2023 = GetFolderId();

                string Folder_2023 = GetFolderId();

                GoogleFile FileMetadata = new GoogleFile()
                {
                    Name = FileInfo.Name,
                    Parents = new List<string> { Folder_2023 }, // Opcional si vols pujar el fitxer a una carpeta específica
                };

                string MimeType = MimeMapping.GetMimeMapping(FileToUpload);

                FilesResource.CreateMediaUpload Request;

                using (FileStream FileStream = new FileStream(FileToUpload, FileMode.Open, FileAccess.Read))
                {

                    DriveService MDriveSerive = GetDriveService.GetDriveServiceMethod();

                    Request = MDriveSerive.Files.Create(FileMetadata, FileStream, MimeType);
                    Request.Fields = "*";

                    try
                    {
                        IUploadProgress Results = Request.Upload();

                        if (Results.Status != UploadStatus.Completed)
                        {
                            throw Results.Exception;
                        }

                        if (Results.Status == UploadStatus.Completed)
                        {
                            Success = true;
                            ExceptionMessage = "Success Upload";
                            string FileId = Request.ResponseBody.Id;
                            SuccesCO = ChangeOwnerFile(MDriveSerive, FileId);
                        }
                    }
                    catch (Exception e)
                    {
                        ExceptionMessage = e.Message;
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                        Success = false;
                    }
                }
            }

            return Success;

        }

        private static bool ChangeOwnerFile(DriveService MDriveSerive, string FileId)
        {
            bool Succes = false;

            if (!string.IsNullOrEmpty(FileId))
            {
                GoogleFile file = MDriveSerive.Files.Get(FileId).Execute();

                Permission UserPermission = new Permission()
                {
                    Type = "user",
                    Role = "owner",
                    EmailAddress = "informatica@ocaglobal.com"
                };

                PermissionsResource.CreateRequest Request = MDriveSerive.Permissions.Create(UserPermission, file.Id);
                Request.TransferOwnership = true;

                try
                {
                    Permission NewPermission = Request.Execute();
                    Succes = true;
                }
                catch (Exception Ex)
                {
                    Succes = false;
                }

            }

            return Succes;
        }

        private static string GetFolderId()
        {
            string FolderId = Properties.Settings.Default.GoogleFolder;
            FolderId = GetGoogleIdFromFolderCompleteUrl(FolderId);
            return FolderId;
        }

        private static string GetGoogleIdFromFolderCompleteUrl(string UrlSheet = "https://drive.google.com/drive/folders/1-HaE-hrX8hqL2Eah-yrtWnfT34S40Yh8")
        {
            string[] Parts = UrlSheet.Split('/');
            string Result = Parts[Parts.Length - 1];
            Parts = Result.Split('?');
            Result = Parts[0];
            return Result;
        }


        private static void GetAllFilesOfUser()
        {

            DriveService MDriveSerive = GetDriveService.GetDriveServiceMethod();
            var nnn = MDriveSerive.Files.List();
            // 'test@example.org' in writers
            nnn.Q = "'albert.turmo@ocaglobal.com' in owners";
            var kdkdk = nnn.Execute();
            var npt = kdkdk.NextPageToken;
        }


        public static List<GoogleFile> GetFiles()
        {
            DriveService MDriveSerive = GetDriveService.GetDriveServiceMethod();

            List<GoogleFile> FoldersList = new List<GoogleFile>();

            FilesResource.ListRequest Result = MDriveSerive.Files.List();

            Result.PageSize = 1000;
            Result.Q = ("'a1@ocaglobal.com' in owners");
            Result.Fields = "nextPageToken, files(*)";

            FileList PartialList;
            do
            {
                PartialList = Result.Execute();
                FoldersList.AddRange(PartialList.Files);
                Result.PageToken = PartialList.NextPageToken;

            } while (PartialList.NextPageToken != null);

            return FoldersList;
        }



    }
}
