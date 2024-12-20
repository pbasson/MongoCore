using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoCore.Core.DTOs;

public class NoteDTO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedDate { get; set; }

}
