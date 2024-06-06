namespace TouristTourGuide.Infrastrucutre
{
    public static class AppFileExtension
    {
       public static string[] allowedExtensions = new[] {".jpg",".png",".jpeg" };
        public static string GenerateUnicFileName(string fileName) 
        {
             int indexOfDot = fileName.IndexOf('.');
            string getSubString = fileName.Substring(indexOfDot);
            if (allowedExtensions.Contains(getSubString))
            {
                return $"{Guid.NewGuid()}{fileName}";
            }
            else 
            {
                return "";
            }
        } 
    }
}
