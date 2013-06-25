using System.Data;
using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using BlogSPA.Domain.Exceptions;

namespace UsersPA.Application
{
    public class UserApplication
    {
        private static Context _Context = ContextManager<Context>.GetCurrentContext();

        public static List<User> Get()
        {
            return _Context.Users.ToList();
        }

        public static User Get(Guid id)
        {
            return _Context.Users.SingleOrDefault(b => b.ID == id);
        }
        
        public static User Get(string name)
        {
            return _Context.Users.SingleOrDefault(b => b.Name == name);
        }

        public static bool Exists(Guid id)
        {
            return _Context.Users.Any(b => b.ID == id);
        }

        public static bool Exists(string username)
        {
            return _Context.Users.Any(b => b.Username == username);
        }

        public static void Save(User user)
        {
            var validation = user.Validate(new ValidationContext(user));
            if (validation.Any())
                throw new InvalidModelState("User", validation.Select(v => v.ErrorMessage));

            bool isNew = user.ID == Guid.Empty;

            if (isNew && Exists(user.Username))
                throw new DuplicateNameException("Já existe um usuário com este nome");

            var entry = _Context.Entry(user);

            if (isNew)
            {
                user.ID = Guid.NewGuid();
                entry.State = EntityState.Added;
            }
            else if (entry.State == EntityState.Detached)
            {
                var attachedEntity = _Context.Set<User>().Find(user.ID);

                if (attachedEntity != null)
                    _Context.Entry(attachedEntity).CurrentValues.SetValues(user);
                else
                    entry.State = EntityState.Modified;
            }

            _Context.SaveChanges();
        }

        public static void Delete(User user)
        {
            _Context.Entry(user).State = EntityState.Deleted;
            _Context.SaveChanges();
        }
    }
}
