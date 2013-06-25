using System.Data;
using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSPA.Application
{
    public class CommentApplication
    {
        public static List<Comment> Get()
        {
            var dbContext = new Context();
            return dbContext.Comments.ToList();
        }

        public static Comment Get(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Comments.SingleOrDefault(b => b.ID == id);
        }

        public static bool Exists(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Comments.Any(b => b.ID == id);
        }

        public static void Save(Comment comment)
        {
            if (String.IsNullOrWhiteSpace(comment.Text))
                throw new ArgumentNullException("Title", "Título não pode ser nulo ou vazio");
            
            var dbContext = new Context();

            if (dbContext.Comments.Any(b => b.Text == comment.Text))
                throw new DuplicateWaitObjectException("Blog", "Já existe um blog com esse título");

            bool isNew = comment.ID == Guid.Empty;
            
            if (isNew)
                comment.ID = Guid.NewGuid();

            dbContext.Entry(comment).State = isNew ? EntityState.Added : EntityState.Modified;

            dbContext.Comments.Add(comment);
            dbContext.SaveChanges();
        }
    }
}
