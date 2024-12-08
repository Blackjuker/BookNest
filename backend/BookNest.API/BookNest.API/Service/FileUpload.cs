
namespace BookNest.API.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly string _uploadDirectory = "Uploads"; // Dossier où les fichiers seront stockés
        public async Task<string> UploadFile(IFormFile file, Guid bookId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException('Fichier Invalid');

            try
            {
                // creer le répertoire 
                Directory.CreateDirectory(_uploadDirectory);

                //Nouveau nom du fichier : GUID + extension originale
                var fileExtension = Path.GetExtension(file.FileName);
                var newFileName = $"{bookId}{fileExtension}";
                var filePath = Path.Combine(_uploadDirectory, newFileName);


                //Copier le fichier 
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return newFileName; //retourne le nouveau nom
            }
            catch(Exception ex)
            {
                throw new Exception("File upload failed.", ex);
            }
        }
    }
}
