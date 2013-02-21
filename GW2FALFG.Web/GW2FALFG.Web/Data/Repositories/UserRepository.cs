using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;
using System.Configuration;


namespace GW2FALFG.Web.Data
{
    public class UserRepository : IUserRepository
    {
        private GroupRequestContext _db { get; set; }

        public UserRepository()
            : this(new GroupRequestContext("LFG"))
        {
        }
        public UserRepository(GroupRequestContext db)
        {
            _db = db;
        }
        public User Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }
        public User VerifyCredentials(string user, string password)
        {
            return _db.Users.SingleOrDefault(e => e.UserName == user && HashPass(e.UserPassword) == HashPass(Decrypt(password)));
        }
        private string Decrypt(string secret)
        {
            //TODO: Need to write decrypt logic for client to server comms
            return "";
        }
        private string HashPass(string secret)
        {
            //TODO: Need to write the one way Hash that is stored
            return "";
        }
    }
}