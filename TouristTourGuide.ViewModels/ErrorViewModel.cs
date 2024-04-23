namespace TouristTourGuide.ViewModels
{
    public class ErrorViewModel
    {
        public string ErrorName = "";
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
