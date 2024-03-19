namespace DentistClinic.Core.Models
{
	public class ContactMsg
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!; 
		public string Phone { get; set; } = null!;
		public string Message { get; set; } = null!;

	}
}
