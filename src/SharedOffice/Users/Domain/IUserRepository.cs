
namespace SharedOffice.Users.Domain
{
	public interface IUserRepository
	{
        
        Task<IEnumerable<Helper>> SearchAllHelpers();
        Task<Helper?> SearchHelperById(Guid helperId);


    }
}

