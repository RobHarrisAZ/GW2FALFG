using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GW2FALFG.Web.Data;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Controllers
{
    public class UserController : ApiController
    {
        public IUserRepository _userRepository { get; set; }

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //
        // GET: /User/
        public HttpResponseMessage Get(string user, string password)
        {
            var response =  Request.CreateResponse(HttpStatusCode.OK);
            if (_userRepository.VerifyCredentials(user, password) == null)
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            return response;
        }

    }
}
