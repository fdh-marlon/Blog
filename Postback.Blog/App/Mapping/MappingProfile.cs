using System;
using Postback.Blog.Areas.Admin.Models;
using Postback.Blog.Models;

namespace Postback.Blog.App.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<InitialUserModel, User>()
                .ForMember(x => x.Active, o => o.UseValue(true))
                .ForMember(u => u.PasswordHashed, o => o.Ignore())
                .ForMember(u => u.PasswordSalt, o => o.Ignore())
                .ForMember(u => u.Id, o => o.Ignore())
                .ConstructUsing(u => new User(u.Password));

            CreateMap<User, UserViewModel>();

            CreateMap<UserEditModel, User>()
                .ForMember(x => x.Active, o => o.UseValue(true))
                .ForMember(u => u.PasswordHashed, o => o.Ignore())
                .ForMember(u => u.PasswordSalt, o => o.Ignore())
                .ConstructUsing(u => new User(u.Password));

            CreateMap<User, UserEditModel>()
                .ForMember(u => u.Password, o => o.Ignore())
                .ForMember(u => u.PasswordConfirm, o => o.Ignore());

            CreateMap<Post, PostViewModel>()
                .ForMember(p => p.Created, o => o.AddFormatter<ReadableDateFormatter>());

            CreateMap<PostEditModel, Post>()
                .ForMember(p => p.Created, o => o.UseValue(DateTime.Now))
                .ForMember(p => p.Author, o => o.Ignore())
                .ForMember(p => p.Uri, o => o.Ignore())
                .ForMember(p => p.Comments, o => o.Ignore())
                .ForMember(p => p.Tags, o => o.ResolveUsing<TagResolver>())
                .ConstructUsing(p => new Post(p.Title));
        }
    }
}