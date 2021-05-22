using Microsoft.AspNet.Identity;
using MRMDataManager.Library.DataAccess;
using MRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MRMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {

        // GET: User/Details/5
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId);
           
        }

    }
}
