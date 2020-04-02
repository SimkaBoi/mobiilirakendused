using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Data
{
    public class CommentData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProfilePicPath { get; set; }
        public string CommentString { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

    }
}
