using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Data
{
    public class UserData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePicPath { get; set; }
    }
}
