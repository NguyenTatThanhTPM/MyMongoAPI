using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoApi.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("title")]
    public string Title { get; set; } = null!;

    [BsonElement("author")]
    public string Author { get; set; } = null!;

    [BsonElement("detail")]
    public string Detail { get; set; } = null!;
}
