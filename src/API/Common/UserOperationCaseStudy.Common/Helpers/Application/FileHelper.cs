using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOperationCaseStudy.Common.Helpers.Application
{
    public class FileHelper
    {
        private const string RootPath = @"\Resources\Uploads";
        public async static Task<string> AddAsync(IFormFile file)
        {
            var result = CreatePath(file);

            try
            {
                var sourcePath = Path.GetTempFileName();
                if(file.Length > 0)
                {
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        await file.CopyToAsync(stream);
                }
                File.Move(sourcePath, result.filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result.directoryPath;
        }

        public async static Task<string> UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = CreatePath(file);
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.filePath, FileMode.Create))
                        await file.CopyToAsync(stream);
                }
                Delete(sourcePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result.directoryPath; 
        }

        public static bool Delete(string path)
        {
            try
            {
                var willDeletePath = Environment.CurrentDirectory + path;
                if (File.Exists(willDeletePath))
                    File.Delete(willDeletePath);
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException(exception.Message);
            }

            return true;
        }

        private static (string filePath, string directoryPath) CreatePath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);

            string fileExtension = fileInfo.Extension;

            var filePath = Guid.NewGuid() + fileExtension;

            string path = Environment.CurrentDirectory + RootPath;

            string directoryPath = $@"{path}\{filePath}";

            return (directoryPath, $"\\Resources\\Uploads\\{filePath}");
        }
    }
}
