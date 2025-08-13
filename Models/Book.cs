using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoApi.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    [Required(ErrorMessage = "Không được để trống")]
    [MaxLength(3,ErrorMessage ="Tối thiểu 3 ký tự")] 
    public string Id { get; set; } = null!;

    [BsonElement("title")]
    [Required(ErrorMessage = "Tiêu đề không được để trống")]
    [MaxLength(5,ErrorMessage ="Tối thiểu 5 ký tự")]
    public string Title { get; set; } = null!;

    [BsonElement("author")]
    [Required(ErrorMessage ="Tác giả không được để trống")]
    public string Author { get; set; } = null!;

    [BsonElement("detail")]
    public string Detail { get; set; } = null!;
}
