using System.Data;
using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSPA.Application
{
    public class TagApplication
    {
        public static List<Tag> Get()
        {
            var dbContext = new Context();
            return dbContext.Tags.ToList();
        }

        public static Tag Get(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Tags.SingleOrDefault(b => b.ID == id);
        }

        public static bool Exists(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Tags.Any(b => b.ID == id);
        }

        public static void Save(Tag tag)
        {
            if (String.IsNullOrWhiteSpace(tag.Title))
                throw new ArgumentNullException("Title", "Título não pode ser nulo ou vazio");
            
            var dbContext = new Context();

            if (dbContext.Blogs.Any(b => b.Title == tag.Title))
                throw new DuplicateWaitObjectException("Blog", "Já existe um blog com esse título");

            bool isNew = tag.ID == Guid.Empty;
            
            if (isNew)
                tag.ID = Guid.NewGuid();

            dbContext.Entry(tag).State = isNew ? EntityState.Added : EntityState.Modified;

            dbContext.Tags.Add(tag);
            dbContext.SaveChanges();
        }
    }
}
