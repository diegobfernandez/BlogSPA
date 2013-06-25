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
    public class CategoryApplication
    {
        private static Context _Context = ContextManager<Context>.GetCurrentContext();

        public static List<Category> Get()
        {
            return _Context.Categories.ToList();
        }

        public static Category Get(Guid id)
        {
            return _Context.Categories.SingleOrDefault(b => b.ID == id);
        }

        public static Category Get(string title)
        {
            return _Context.Categories.SingleOrDefault(b => b.Title.Trim() == title.Trim());
        }

        public static bool Exists(Guid id)
        {
            return _Context.Categories.Any(b => b.ID == id);
        }

        public static void Save(Category category)
        {
            var validation = category.Validate(new ValidationContext(category));
            
            if (validation.Any())
                throw new InvalidModelState("Category", validation.Select(v => v.ErrorMessage));

            bool isNew = category.ID == Guid.Empty;

            if (isNew && _Context.Categories.Any(b => b.Title.Trim() == category.Title.Trim()))
                throw new InvalidModelState("Category", "Já existe uma categoria com esse título");

            var entry = _Context.Entry(category);

            if (isNew)
            {
                category.ID = Guid.NewGuid();
                entry.State = EntityState.Added;
            }
            else if (entry.State == EntityState.Detached)
            {
                var attachedEntity = _Context.Set<Category>().Find(category.ID);

                if (attachedEntity != null)
                    _Context.Entry(attachedEntity).CurrentValues.SetValues(category);
                else
                    entry.State = EntityState.Modified;
            }

            _Context.SaveChanges();
        } 
    }
}
