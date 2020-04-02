using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Data
{
    public class LikeData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
