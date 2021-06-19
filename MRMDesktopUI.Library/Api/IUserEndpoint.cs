using MRMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRMDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
    }
}