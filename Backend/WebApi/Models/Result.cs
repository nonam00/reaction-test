using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Domain
{
	[Serializable]
	public class Result
	{
		public int UserId { get; set; }
		[BsonId]
		public Guid Id { get; set; }
		public string Username { get; set; } = string .Empty;
		public int ReactionTime { get; set; }
		public DateTime TestDate { get; set; }
	}
}