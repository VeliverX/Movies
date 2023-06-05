using MongoDB.Bson.Serialization.Attributes;

namespace MoviesAPI.Data
{
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; } 
        public string title { get; set; }
        public int year { get; set; }
        public string summary { get; set; }
        
    }
}
