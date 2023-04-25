
namespace Backend.Controllers.Users.Models;

public class UserGetResponseDTO
{
	public Guid UserId { get; set; }
	public string CompleteName { get; set; } = string.Empty;
	public string PhoneNumber { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string PicturePath { get; set; } = string.Empty;
	public string AboutMe { get; set; } = string.Empty;
	public int Rating { get; set; }
}


