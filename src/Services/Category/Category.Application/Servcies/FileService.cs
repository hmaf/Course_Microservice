using Category.Application.Contracts.FileTypes;
using Category.Application.Dtos.File;
using Category.Application.Servcies.IServices;
using Microsoft.VisualBasic.FileIO;

namespace Category.Application.Servcies
{
    public class FileService : IFileService
    {
        public async Task<string> UploadFile(FileB64 file, string FileAddress)
        {
            try
            {
                if (string.IsNullOrEmpty(file.FileType)) return "NoIcon.png";
             
                //if (!string.IsNullOrEmpty(file.FileType) && !FileType.File_Type.Title.Contains(file.FileType))
                if (!string.IsNullOrEmpty(file.FileType) && !FileType.File_Type.IsValid(file.FileType))
                        throw new System.Exception("نوع فایل وارد شده معتبر نمیباشد");

                string fileName = Guid.NewGuid().ToString() + file.FileType;
                var folderDirectory = $"wwwroot\\{FileAddress}";
                var path = Path.Combine("wwwroot", FileAddress, fileName);

                var memoryStream = new MemoryStream();

                if (!Directory.Exists(folderDirectory))
                    Directory.CreateDirectory(folderDirectory);

                var files = Convert.FromBase64String(file.File);

                File.WriteAllBytes(path, files);

                return fileName;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        public bool Delete(string fileName, string fileAddress)
        {
            if (string.IsNullOrEmpty(fileName)) return false;

            var path = $"wwwroot\\{fileAddress}\\{fileName}";
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }

        string[] fileTypes = { ".png" };
    }
}
