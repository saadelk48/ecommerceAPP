using ecommerceAPP.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ecommerceAPP.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadFile(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("Fichier non valide.");
            }

            var uploadsPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            if (!Directory.Exists(uploadsPath))
            {
                Console.WriteLine($"📂 [DEBUG] Creating directory: {uploadsPath}");
                Directory.CreateDirectory(uploadsPath);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadsPath, uniqueFileName);

            Console.WriteLine($"📂 [DEBUG] Full file path: {filePath}");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            Console.WriteLine("✅ [DEBUG] File successfully saved!");

            return "/" + folderPath + "/" + uniqueFileName;
        }

    }
}
