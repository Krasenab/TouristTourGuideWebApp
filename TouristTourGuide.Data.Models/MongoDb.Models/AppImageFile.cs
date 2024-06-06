using MongoDB.Bson;

namespace TouristTourGuide.Data.Models.MongoDb.Models
{
    public class AppImageFile
    {
        public ObjectId Id { get; set; }
        public byte[] FileData { get; set; }
        public string UniqueFileName { get; set; }
    }
}
