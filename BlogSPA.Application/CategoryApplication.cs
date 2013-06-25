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
        public static List<Category> Get()
        {
            var dbContext = new Context();
            return dbContext.Categories.ToList();
        }

        public static Category Get(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Categories.SingleOrDefault(b => b.ID == id);
        }

        public static Category Get(string title)
        {
            var dbContext = new Context();
            return dbContext.Categories.SingleOrDefault(b => b.Title.Trim() == title.Trim());
        }

        public static bool Exists(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Categories.Any(b => b.ID == id);
        }

        public static void Save(Category category)
        {
            var validation = category.Validate(new ValidationContext(category));
            
            if (validation.Any())
                throw new InvalidModelState("Category", validation.Select(v => v.ErrorMessage));

            var dbContext = new Context();

            if (dbContext.Categories.Any(b => b.Title == category.Title))
                throw new InvalidModelState("Category", "Já existe uma categoria com esse título");

            bool isNew = category.ID == Guid.Empty;
            
            if (isNew)
                category.ID = Guid.NewGuid();

            dbContext.Entry(category).State = isNew ? EntityState.Added : EntityState.Modified;

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        } 
    }
}
