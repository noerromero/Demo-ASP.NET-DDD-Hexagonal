namespace Frontend.Models.Pets
{
	public class Pet
	{
		public Guid PetId { get; set; } 
		public string Name { get; set; } = string.Empty;
		public string Age { get; set; } = string.Empty;
	}
}

