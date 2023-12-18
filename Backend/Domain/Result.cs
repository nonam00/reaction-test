namespace Backend.Domain
{
	[Serializable]
	public class Result
	{
		public int UserId { get; set; }
		public Guid Id { get; set; }
		public string Username { get; set; } = string .Empty;
		public int ReactionTime { get; set; }
		public DateTime TestDate { get; set; }
	}
}