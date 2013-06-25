using System.Data;
using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UsersPA.Application
{
    public class UserApplication
    {
        public static List<User> Get()
        {
            var dbContext = new Context();
            return dbContext.Users.ToList();
        }

        public static User Get(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Users.SingleOrDefault(b => b.ID == id);
        }

        public static bool Exists(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Users.Any(b => b.ID == id);
        }

        public static void Save(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentNullException("Title", "Título não pode ser nulo ou vazio");
            
            var dbContext = new Context();

            if (dbContext.Users.Any(b => b.Name == user.Name))
                throw new DuplicateWaitObjectException("Blog", "Já existe um blog com esse título");

            bool isNew = user.ID == Guid.Empty;
            
            if (isNew)
                user.ID = Guid.NewGuid();

            dbContext.Entry(user).State = isNew ? EntityState.Added : EntityState.Modified;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}
