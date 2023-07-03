

namespace GoogleServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetFiles();

            // GetAllFilesOfUser();

            // ChangeOwnerFile();


            var a = UsersManagement.GetUser("albert.turmo@ocaglobal.com");


            string FileToUpload = @"C:\DonwloadExports_02\100K.txt";

            UploadFile.UploadFileToGoogleDrive(FileToUpload, out string ExceptionMessage, out bool SuccesCO);

        }

    }
}
