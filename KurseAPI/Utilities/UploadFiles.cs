namespace KurseAPI.Utilities
{
    public static class UploadFiles
    {
        public static bool TestImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var extension = Path.GetExtension(file.FileName).ToUpperInvariant();
            return extension is ".JPG" or ".JPEG" or ".PNG" or ".GIF";
        }

        public static string WriteFiles(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "";

            try
            {
                var extension = Path.GetExtension(file.FileName).ToUpperInvariant();
                var nameUnique = Guid.NewGuid().ToString() + extension;

                // folder combine
                var folder = Path.Combine("wwwroot", "folder");

                // folder erstellen falls micht exist
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                // path
                var filePath = Path.Combine(folder, nameUnique);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // 
                return $"/folder/{nameUnique}";
            }
            catch
            {
                return "";
            }
        }

    }

}
