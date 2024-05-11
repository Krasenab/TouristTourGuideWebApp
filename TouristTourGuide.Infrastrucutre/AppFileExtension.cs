namespace TouristTourGuide.Infrastrucutre
{
    public static class AppFileExtension
    {
       public static string[] allowedExtensions = new[] {".jpg",".png",".jpeg" };
        public static string GenerateUnicFileName(string fileName) 
        {
            return $"{Guid.NewGuid()}{fileName}";
        } 
    }
}
