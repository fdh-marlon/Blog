using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Postback.Blog.Models
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}