namespace Frontend.Models.Appointments
{
	public class Receiver
	{
		public Guid ReceiverId { get; set; }
		public Guid ToUserId { get; set; }
		public Guid AppointmentId { get; set; }
	}
}

