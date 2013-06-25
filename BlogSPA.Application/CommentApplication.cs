using System.Data;
using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using BlogSPA.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace BlogSPA.Application
{
    public class CommentApplication
    {
        private static Context _Context = ContextManager<Context>.GetCurrentContext();

        public static List<Comment> Get()
        {
            return _Context.Comments.ToList();
        }

        public static Comment Get(Guid id)
        {
            return _Context.Comments.SingleOrDefault(b => b.ID == id);
        }

        public static bool Exists(Guid id)
        {
            return _Context.Comments.Any(b => b.ID == id);
        }

        public static void Save(Comment comment)
        {
            var validation = comment.Validate(new ValidationContext(comment));
            if (validation.Any())
                throw new InvalidModelState("Comment", validation.Select(v => v.ErrorMessage));

            var entry = _Context.Entry(comment);

            if (comment.ID == Guid.Empty)
            {
                comment.ID = Guid.NewGuid();
                entry.State = EntityState.Added;
            }
            else if (entry.State == EntityState.Detached)
            {
                var attachedEntity = _Context.Set<Comment>().Find(comment.ID);

                if (attachedEntity != null)
                    _Context.Entry(attachedEntity).CurrentValues.SetValues(comment);
                else
                    entry.State = EntityState.Modified;
            }

            _Context.SaveChanges();
        }

        public static void Delete(Comment comment)
        {
            _Context.Entry(comment).State = EntityState.Deleted;
            _Context.SaveChanges();
        }
    }
}
