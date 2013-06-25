using System.Data;
using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using BlogSPA.Domain.Exceptions;

namespace BlogSPA.Application
{
    public class PostApplication
    {
        private static Context _Context = ContextManager<Context>.GetCurrentContext();

        public static List<Post> Get(int skip = 0, int take = 0)
        {
            var query = _Context.Posts.OrderByDescending(p => p.PublicationDate).Skip(skip) as IQueryable<Post>;

            if (take > 0)
                query = query.Take(take);

            return query.ToList();
        }

        public static Post Get(Guid id)
        {
            return _Context.Posts.SingleOrDefault(b => b.ID == id);
        }

        public static Post Get(string slug)
        {
            return _Context.Posts.SingleOrDefault(b => b.Slug == slug);
        }

        public static bool Exists(Guid id)
        {
            return _Context.Posts.Any(b => b.ID == id);
        }

        public static void Save(Post post, Guid? blogID = null)
        {
            if (blogID.HasValue)
                post.Blog = BlogApplication.Get(blogID.Value);

            post.Slug = post.Title;

            var validation = post.Validate(new ValidationContext(post));
            if (validation.Any())
                throw new InvalidModelState("Post", validation.Select(v => v.ErrorMessage));

            bool isNew = post.ID == Guid.Empty;
            var entry = _Context.Entry(post);

            if (isNew)
            {
                post.ID = Guid.NewGuid();
                entry.State = EntityState.Added;
            }
            else if (entry.State == EntityState.Detached)
            {
                var attachedEntity = _Context.Set<Post>().Find(post.ID);

                if (attachedEntity != null)
                    _Context.Entry(attachedEntity).CurrentValues.SetValues(post);
                else
                    entry.State = EntityState.Modified;
            }
            
            _Context.SaveChanges();
        }

        public static void Delete(Post post)
        {
            _Context.Entry(post).State = EntityState.Deleted;
            _Context.SaveChanges();
        }
    }
}
