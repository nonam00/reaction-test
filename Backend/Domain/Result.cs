namespace Backend.Domain
{
	public class Result
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public int ReactionTime { get; set; }
		public DateTime TestDate { get; set; }
	}
}