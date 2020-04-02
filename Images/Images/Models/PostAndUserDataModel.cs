using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Models
{
    class PostAndUserDataModel
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicPath { get; set; }
    }
}
