﻿using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Postback.Blog.ViewModels
{
    public class AuthenticationModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}