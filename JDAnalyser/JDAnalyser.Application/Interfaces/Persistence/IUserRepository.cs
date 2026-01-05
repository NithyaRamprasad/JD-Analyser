using JDAnalyser.Domain.Models.User;

namespace JDAnalyser.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserDetails(string emailId);
    }
}
