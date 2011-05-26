﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace Postback.Blog.ViewModels
{
    public class InitialUserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Email]
        [Remote("isunique","user","api")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EqualTo("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}