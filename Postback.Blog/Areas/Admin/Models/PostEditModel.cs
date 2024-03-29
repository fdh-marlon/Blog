﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Norm;

namespace Postback.Blog.Areas.Admin.Models
{
    public class PostEditModel
    {
        public ObjectId Id { get; set; }

        [Required]
        [Remote("isunique", "post", "api", AdditionalFields = "Id")]
        public string Title { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Body { get; set; }
    }
}