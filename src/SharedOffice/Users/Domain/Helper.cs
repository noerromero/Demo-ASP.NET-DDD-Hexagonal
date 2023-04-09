
namespace SharedOffice.Users.Domain
{
	public class Helper: User
	{
		public string AboutMe { get; private set; }
		public int Ratin { get; private set; }

		private Helper(){}

		public Helper(string firstName, string lastName, string phoneNumber, string email, string picturePath,
						string aboutMe, int ratin)
					: base(firstName, lastName, phoneNumber, email, picturePath)
        {

			AboutMe = aboutMe;
			Ratin = ratin;
		}

	}
}

