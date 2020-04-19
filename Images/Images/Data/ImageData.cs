using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Data
{
    public class ImageData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string UserPic { get; set; }
        public string UserName { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
}
