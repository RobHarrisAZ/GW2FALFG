﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GW2FALFG.Web.Controllers
{
    public class GroupController : ApiController
    {
        // GET api/group
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/group/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/group
        public void Post([FromBody]string value)
        {
        }

        // PUT api/group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/group/5
        public void Delete(int id)
        {
        }

        public string Index()
        {
            return "<html><body><div><strong>Sorry, but you're doing it wrong...<strong></div></body></html>";
        }
    }
}