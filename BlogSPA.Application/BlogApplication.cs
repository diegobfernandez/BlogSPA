using System.Data;
using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSPA.Application
{
    public class BlogApplication
    {
        public static List<Blog> Get()
        {
            var dbContext = new Context();
            return dbContext.Blogs.ToList();
        }

        public static Blog Get(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Blogs.SingleOrDefault(b => b.ID == id);
        }

        public static bool Exists(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Blogs.Any(b => b.ID == id);
        }

        public static void Save(Blog blog)
        {
            if (String.IsNullOrWhiteSpace(blog.Title))
                throw new ArgumentNullException("Title", "Título não pode ser nulo ou vazio");
            
            var dbContext = new Context();

            if (dbContext.Blogs.Any(b => b.Title == blog.Title))
                throw new DuplicateWaitObjectException("Blog", "Já existe um blog com esse título");

            bool isNew = blog.ID == Guid.Empty;
            
            if (isNew)
                blog.ID = Guid.NewGuid();

            dbContext.Entry(blog).State = isNew ? EntityState.Added : EntityState.Modified;

            dbContext.Blogs.Add(blog);
            dbContext.SaveChanges();
        }

        public static void Put(Guid id, Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
