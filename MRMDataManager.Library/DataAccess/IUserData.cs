using MRMDataManager.Library.Models;

namespace MRMDataManager.Library.DataAccess
{
    public interface IUserData
    {
        UserModel GetUserById(string Id);
    }
}