

namespace TouristTourGuide.ViewModels.AppUserViewModels
{
   public class ProfileViewModel
    {
        public string AppUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public string FaceBookUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? ImageByte { get; set; }
    }
}
