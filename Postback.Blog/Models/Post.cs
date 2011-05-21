﻿using System.Collections.Generic;

namespace Postback.Blog.Models
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string Body { get; set; }
        public string Created { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Comment> Comments { get; set; }
        public User Author { get; set; }
    }
}