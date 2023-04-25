
using SharedOffice.Users.Domain;

namespace SharedOffice.Users.Application
{
	public class UserSearcher
	{
		private IUserRepository _repository;

		public UserSearcher(IUserRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

        public async Task<IEnumerable<Helper>> SearchAllHelpers()
        {
            return await _repository.SearchAllHelpers();
        }
    }
}

