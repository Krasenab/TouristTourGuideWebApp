namespace TouristTourGuide.ViewModels.AppImageViewModels
{
     public class AppImagesViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string? TouristTourId { get; set; }
        public string? ApplicationUserId { get; set; }
        public string UniqueFileName { get; set; }
        public byte[] FileData { get; set; }        
    }
}
