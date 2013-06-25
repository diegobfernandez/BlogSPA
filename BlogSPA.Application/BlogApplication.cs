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
    public class BlogApplication
    {
        private static Context _Context = ContextManager<Context>.GetCurrentContext();

        public static List<Blog> Get()
        {
            return _Context.Blogs.ToList();
        }

        public static Blog Get(Guid id)
        {
            return _Context.Blogs.SingleOrDefault(b => b.ID == id);
        }

        public static bool Exists(Guid id)
        {
            return _Context.Blogs.Any(b => b.ID == id);
        }

        public static void Save(Blog blog)
        {
            var validation = blog.Validate(new ValidationContext(blog));
            if (validation.Any())
                throw new InvalidModelState("Blog", validation.Select(v => v.ErrorMessage));

            bool isNew = blog.ID == Guid.Empty;

            if (isNew && _Context.Blogs.Any(b => b.Title == blog.Title))
                throw new DuplicateWaitObjectException("Blog", "Já existe um blog com esse título");

            var entry = _Context.Entry(blog);

            if (isNew)
            {
                blog.ID = Guid.NewGuid();
                entry.State = EntityState.Added;
            }
            else if (entry.State == EntityState.Detached)
            {
                var attachedEntity = _Context.Set<Blog>().Find(blog.ID);

                if (attachedEntity != null)
                    _Context.Entry(attachedEntity).CurrentValues.SetValues(blog);
                else
                    entry.State = EntityState.Modified;
            }

            _Context.SaveChanges();
        }

        public static void Delete(Blog blog)
        {
            _Context.Entry(blog).State = EntityState.Deleted;
            _Context.SaveChanges();
        }
    }
}
