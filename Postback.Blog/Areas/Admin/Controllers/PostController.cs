﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Norm;
using Postback.Blog.App.Data;
using Postback.Blog.App.Services;
using Postback.Blog.Areas.Admin.Models;
using Postback.Blog.Models;

namespace Postback.Blog.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private IPersistenceSession session;

        public PostController(IPersistenceSession session)
        {
            this.session = session;
        }

        public ActionResult Index(int? page)
        {
            var posts = this.session.All<Post>()
                .Skip(page.HasValue ? ((page.Value - 1) * Settings.PageSize) : 0)
                .Take(Settings.PageSize)
                .Select(u => Mapper.Map<Post, PostViewModel>(u))
                .ToList();

            return View(posts);
        }

        public ActionResult Edit(ObjectId id)
        {
            var post = session.Single<Post>(u => u.Id == id);
            if (post != null)
            {
                return View(Mapper.Map<Post, PostEditModel>(post));
            }

            return View(new PostEditModel());
        }

        [HttpPost]
        public ActionResult Edit(PostEditModel model)
        {
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<PostEditModel, Post>(model);
                session.Save<Post>(post);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(ObjectId id)
        {
            var post = session.Single<Post>(u => u.Id == id);
            if (post != null)
            {
                session.Delete<Post>(post);
            }

            return RedirectToAction("Index");
        }
    }
}
