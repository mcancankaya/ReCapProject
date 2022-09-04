using Core.Utilities.Business;
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
            var result = CheckIfFileExists(filePath);
            if (!result.Success)
            {
                return result;
            }
            File.Delete(filePath);
            return new SuccessResult("Resim Silindi.");

        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            var resultOfDelete = Delete(filePath);

            if (!resultOfDelete.Success)
            {
                return resultOfDelete;
            }

            var resultOfUpload = Upload(file, root);
            return new SuccessResult(resultOfUpload.Message);
        }

        public IResult Upload(IFormFile file, string root)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(file),
                CheckIfFileExtensionValid(Path.GetExtension(file.FileName)));

            if (result != null)
            {
                return result;
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            CheckIfDirectoryExists(root);
            CreateFile(root + fileName, file);
            return new SuccessResult(fileName);
        }

        //Rules
        private IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya mevcut değil");
        }

        private IResult CheckIfFileEnter(IFormFile file)
        {
            if (file.Length < 0)
            {
                return new ErrorResult("Dosya girilmemiş");
            }
            return new SuccessResult();
        }

        private IResult CheckIfFileExtensionValid(string extension)
        {
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".webp")
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya uzantısı geçerli değil");
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
