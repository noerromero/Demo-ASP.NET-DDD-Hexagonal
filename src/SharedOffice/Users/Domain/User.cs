
using SharedCore.Domain.Aggregate;
using SharedCore.Domain.Entity;

namespace SharedOffice.Users.Domain
{
	public abstract class User : BaseEntity<Guid>, IAggregateRoot
    {
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Email { get; private set; }
		public string PicturePath { get; private set; }


		protected User() {}

		public User(string firstName, string lastName, string phoneNumber, string email, string picturePath) {
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			Email = email;
			PicturePath = picturePath;
		}

		public string CompleteName() => FirstName + " " + LastName;

		
	}
}

