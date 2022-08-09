using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public IResult Delete(string filePath)
        {
            var result = CheckIfFileExist(filePath);
            if (!result.Success)
            {
                return result;
            }
            File.Delete(filePath);
            return new SuccessResult("Resim Silindi.");

        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            throw new NotImplementedException();
        }

        public IResult Upload(IFormFile file, string root)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            
            CheckIfDirectoryExists(root);
            
            CreateFile(root + fileName, file);

            return new SuccessResult(fileName);
        }

        //Rules

        private IResult CheckIfFileExist(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResults("Bu Dosya Mevcut Değil.");
        }
        private void CheckIfDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private void CreateFile(string directory, IFormFile file)
        {
            //Yeni bir dosya oluşturulur ve eğer aynı isimde bir dosya bulunuyorsa üzerine yazılır.
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream); //Oluşturduğumuz dosyanın içine resmi kopyaladık.
                fileStream.Flush(); //Tampondaki bilgilerin boşaltılmasını ve stream dosyasının güncellenmesini sağlar.
            }
        }
    }
}
